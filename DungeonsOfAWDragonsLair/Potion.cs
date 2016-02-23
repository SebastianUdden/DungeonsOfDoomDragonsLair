using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfAWDragonsLair
{
    class Potion: Item
    {
        public int Health { get; set; }

        public Potion(string name, int weight, int health):base(name,weight)
        {
            Health = health; 
        }

        public override void PickUp(Player player)
        {
      
            player.Health += Health;
        }

    }
}
