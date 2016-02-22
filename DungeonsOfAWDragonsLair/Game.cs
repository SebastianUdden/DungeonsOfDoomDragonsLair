using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DungeonsOfAWDragonsLair
{
    class Game
    {
        
        List<Item> itemsInWorld = new List<Item>() { new Item("Sword", 10), new Item("Shield", 15), new Item("Boots", 5), new Item("Axe", 20), new Item("Potion", 1), new Item("Dragon", 500) };
        const int WorldWidth = 20;
        const int WorldHeight = 10;
        Player player;
        Room[,] world;
        bool backPackFull = false;
        bool monsterHere = false;
        Music music = new Music();
        public void Start()
        {
            music.IntroMusic();
            CreatePlayer();
            CreateWorld();
            do
            {
                Console.Clear();
                DisplayWorld();
                Console.BackgroundColor = ConsoleColor.Black;
                DisplayStats();
                AskForMovement();
                //player.Health--;
            } while (player.Health > 0);
            GameOver();
        }
        private void DisplayStats()
        {
            Console.WriteLine($"Name: {player.Name}");
            Console.WriteLine($"Health: {player.Health}");
            Console.WriteLine($"Pos: {player.X}:{player.Y}");
            foreach (var item in player.BackPack)
            {
                if (item.Name == "Sword" || item.Name == "Axe")
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                else if (item.Name == "Shield" || item.Name == "Boots")
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                }
                else if (item.Name == "Potion")
                {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                }
                Console.WriteLine(item.Name);
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine($"Total weight: {player.BackPack.Sum(x => x.Weight)}");
            if (backPackFull)
            {
                Console.WriteLine($"Item to big, can't fit in backpack!");
            }
            else
            {
                Console.WriteLine("You picked up item!");
            }
            if (monsterHere)
            {
                Console.WriteLine("there is a monster in this room");
            }
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
                    Item item = new Item(world[x, y].ItemInRoom.Name, world[x, y].ItemInRoom.Weight);
                    if ((player.BackPack.Sum(a => a.Weight) + item.Weight) <= 100)
                    {
                        PickUpItem(item);
                        world[x, y].ItemInRoom = null;
                        backPackFull = false;
                    }
                    else
                    {
                        music.CantPickUpItemSFX();
                        backPackFull = true;
                    }
                    //kommentar
                }
                if (world[x, y].MonsterInRoom != null)
                {
                    if (world[x, y].MonsterInRoom.Name == "Ogre")
                    {
                        Console.WriteLine("You encountered a twoheaded Ogre, strike it down twice (Press enter to continue)");
                        music.BattleMusic();
                        Console.ReadLine();
                    }
                    else if (world[x, y].MonsterInRoom.Name == "Gremlin")
                    {
                        Console.WriteLine("You encountered a squemish Gremlin, and it immediately scurried down a hole. (Press enter to continue)");
                        music.WinFight();
                        Console.ReadLine();
                    }
                    player.Fight(world[x, y].MonsterInRoom);
                    if (world[x, y].MonsterInRoom.Health > 0)
                    {
                        world[x, y].MonsterInRoom.Fight(player);
                    }
                    monsterHere = true;
                }
                else
                    monsterHere = false;
            }
        }
        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over");
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
            player = new Player("Player", 100, 25);
        }
        private void DisplayWorld()
        {
            
            for (int y = 0; y < WorldHeight; y++)
            {
                for (int x = 0; x < WorldWidth; x++)
                {
                    Room room = world[x, y];
                    if (player.X == x && player.Y == y)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write('P');
                    }
                    else if (room.MonsterInRoom != null && room.MonsterInRoom.Health>0)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Monster monster = room.MonsterInRoom;
                        Console.Write(room.MonsterInRoom.Name[0]);
                    }
                    else if (room.ItemInRoom != null)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Item item = room.ItemInRoom;
                        Console.Write('I');
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write('.');
                    }
                }
                Console.WriteLine();
            }
        }
        private void PickUpItem(Item item)
        {
            player.BackPack.Add(item);
            music.PickUpItemSFX();
        }
    }
}