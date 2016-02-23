using DungeonsOfAWDragonsLair;
using Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items
{
    abstract class Item : GameObject, ILuggable
    {
        public ConsoleColor Color { get; set; }
        public Item(string name, int weight, ConsoleColor color) : base(name)
        {
            Color = color;
            Weight = weight;
        }
        public int Weight { get; set; }
        public abstract void PickUp(Player player); 
    }
}
