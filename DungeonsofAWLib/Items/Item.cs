﻿using DungeonsOfAWLib;
using Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Elements;

namespace Items
{
    internal abstract class Item : GameObject, ILuggable
    {
        public ConsoleColor Color { get; set; }
        internal Item(string name, int weight, ConsoleColor color) : base(name)
        {
            Color = color;
            Weight = weight;
        }
        public int Weight { get; set; }
        public abstract void PickUp(Player player); 
    }
}
