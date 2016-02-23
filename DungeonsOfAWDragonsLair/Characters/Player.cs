﻿using DungeonsOfAWDragonsLair;
using Interfaces;
using Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters
{
    sealed class Player : Character
    {
        public Player(string name, int health, int attackStrength) : base(name, health, attackStrength)
        {
            BackPack = new List<ILuggable>();
        }
        public int X { get; set; }

        public int Y { get; set; }

        public List<ILuggable> BackPack { get; set; }

        public override string Message(Character opponent)
        {
            return "player message";
        }

        public override void Fight(Character opponent)
        {
            opponent.Health -= AttackStrength;
        }
    }
}
