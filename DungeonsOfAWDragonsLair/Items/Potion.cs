using DungeonsOfAWDragonsLair;
using Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items
{
    class Potion: Item
    {
        public int Health { get; set; }

        public Potion(string name, int weight, int health, ConsoleColor color):base(name,weight, color)
        {
            Health = health; 
        }

        public override void PickUp(Player player)
        {
      
            player.Health += Health;
        }

    }
}
