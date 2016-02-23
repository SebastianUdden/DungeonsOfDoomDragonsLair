﻿using Items;
using Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfAWDragonsLair
{
    interface ILuggable
    {
        int Weight { get; set; }
        string Name { get; }
        ConsoleColor Color { get;}
        void PickUp(Player player);
    }
}
