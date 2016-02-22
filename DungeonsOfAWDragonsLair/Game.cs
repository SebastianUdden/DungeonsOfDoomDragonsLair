using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace DungeonsOfAWDragonsLair
{
    class Game
    {
        
        List<Item> itemsInWorld = new List<Item>() { new Potion("Blue potion", 2, -20), new Potion("Yellow potion", 2, 5), new Potion("Red potion", 2,20), new Sword("Sword", 10, 15) , new Axe("Axe",3,10)/*, new Item("Shield", 15), new Item("Boots", 5), new Item("Axe", 20), new Item("Potion", 1), new Item("Dragon", 500) */};
        const int WorldWidth = 20;
        const int WorldHeight = 10;
        Player player;
        Room[,] world;
        public static int CurrentAction = 1;
        bool backPackFull = false;
        //bool monsterHere = false;
        Music music = new Music();
        public void Start()
        {
            DelayMessage(@"The resourceful knight continues the quest for vengeance against 
the mighty Z'hur. He must collect items to increase his strength 
and defeat the devious monsters 'hidden' throughout the map.");
            music.IntroMusic();
            CreatePlayer();
            CreateWorld();
            Parallel.Invoke(() =>
            {
                    MusicLoop();
            },
                            () =>
                            {
                                do
                                {
                                    Console.Clear();
                                    DisplayWorld();
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    DisplayStats();
                                    AskForMovement();
                                } while (player.Health > 0);
                                GameOver();
                            } 
                        );
        }

        public void MusicLoop()
        {
            if (CurrentAction == 1)
            {
                music.AdventureMusic();
            }
            else if (CurrentAction == 2)
            {
                music.BattleMusic();
                CurrentAction = 1;
                MusicLoop();
            }
            else if (CurrentAction == 3)
            {
                music.WinFight();
                CurrentAction = 1;
                MusicLoop();
            }

            MusicLoop();
        }

        public static void DelayMessage(string message, int msDelay = 20)
        {
            for (int i = 0; i < message.Count(); i++)
            {
                Console.Write(message[i]);
                Thread.Sleep(msDelay);
            }
        }
        private void DisplayStats()
        {
            Console.WriteLine($"Name: {player.Name}");
            Console.WriteLine($"Health: {player.Health}");
            Console.WriteLine($"Attack: {player.AttackStrength}");
            Console.WriteLine($"Pos: {player.X}:{player.Y}");
            foreach (var item in player.BackPack)
            {
                if (item.Name == "Sword" || item.Name == "Axe")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (item.Name == "Shield" || item.Name == "Boots")
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                else if (item.Name == "Potion")
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                Console.WriteLine(item.Name);
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine($"Total weight: {player.BackPack.Sum(x => x.Weight)}");
            }
        private void AskForMovement()
        {
            Console.WriteLine("Move!");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            int x = player.X;
            int y = player.Y;
            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow: x++; break;
                case ConsoleKey.LeftArrow: x--; break;
                case ConsoleKey.UpArrow: y--; break;
                case ConsoleKey.DownArrow: y++; break;
            }
            if (x >= 0 && x < WorldWidth && y >= 0 && y < WorldHeight)
            {
                player.X = x;
                player.Y = y;
                if (world[x, y].ItemInRoom != null)
                {
                    
                    if ((player.BackPack.Sum(a => a.Weight) + world[x, y].ItemInRoom.Weight) <= 100)
                    {
                        DelayMessage("You picked up item!");
                        music.PickUpItemSFX();
                        world[x, y].ItemInRoom.PickUpItem(player);
                        world[x, y].ItemInRoom = null;
                        backPackFull = false;
                    }
                    else
                    {
                        music.CantPickUpItemSFX();
                        DelayMessage($"Dragon is to big, can't fit in backpack... You need to obtain truck first!");
                        backPackFull = true;
                    }
                    //kommentar
                }
                if (world[x, y].MonsterInRoom != null)
                {
                    if (world[x,y].MonsterInRoom.Name == "Ogre")
                    {
                        CurrentAction = 2;
                    }
                    else
                    {
                        CurrentAction = 3;
                    }
                    DelayMessage(world[x, y].MonsterInRoom.Message(player));
                        Console.ReadLine();
               
                    player.Fight(world[x, y].MonsterInRoom);
                    if (world[x, y].MonsterInRoom.Health > 0)
                    {
                        world[x, y].MonsterInRoom.Fight(player);
                    }
                    else
                    {
                        world[x, y].MonsterInRoom = null;
                    }
                    //monsterHere = true;
                }
                
                    //monsterHere = false;
            }
        }
        private void GameOver()
        {
            Console.Clear();
            DelayMessage("Game Over");
        }

        
        private void CreateWorld()
        {
            Random rndGen = new Random();
            world = new Room[WorldWidth, WorldHeight];
            for (int y = 0; y < WorldHeight; y++)
            {
                for (int x = 0; x < WorldWidth; x++)
                {

                    Room room = new Room();
                    if (rndGen.Next(0, 26) > 24)
                    {
                        if (rndGen.Next(0, 2) == 1)
                            room.MonsterInRoom = new Ogre("Ogre", 30, 10);
                        else
                            room.MonsterInRoom = new Gremlin("Gremlin", 10, 5);
                    }
                    if (rndGen.Next(0, 21) > 19 && itemsInWorld.Count() > 0)
                    {
                        int rng = rndGen.Next(0, itemsInWorld.Count());
                        room.ItemInRoom = itemsInWorld[rng];
                        itemsInWorld.RemoveAt(rng);
                    }
                    world[x, y] = room;
                }
            }
        }
        private void CreatePlayer()
        {
            player = new Player("Player", 100, 2);
        }
        private void DisplayWorld()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;

            for (int y = 0; y < WorldHeight; y++)
            {
                for (int x = 0; x < WorldWidth; x++)
                {
                    Room room = world[x, y];
                    if (player.X == x && player.Y == y)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;                        
                        Console.Write('P');
                    }
                    else if (room.MonsterInRoom != null && room.MonsterInRoom.Health>0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Monster monster = room.MonsterInRoom;
                        Console.Write(room.MonsterInRoom.Name[0]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (room.ItemInRoom != null)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Item item = room.ItemInRoom;
                        Console.Write(item.Name.Substring(0,1));
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write(' ');
                }
                }
                Console.WriteLine();
            }
        }
       
    }
}