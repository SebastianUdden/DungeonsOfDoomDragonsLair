﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfAWDragonsLair
{
    sealed class Player : Character
    {
        public Player(string name, int health, int attackStrength) : base(name, health, attackStrength)
        {
            BackPack = new List<Item>();
        }
        public int X { get; set; }

        public int Y { get; set; }

        public List<Item> BackPack { get; set; }

        public override string Message()
        {
            return "player message";
        }

        public override void Fight()
        {
            throw new NotImplementedException();
        }
    }
}
