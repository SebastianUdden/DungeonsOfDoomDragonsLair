using DungeonsOfAWLib;
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
        internal Player(string name, int health, int attackStrength) : base(name, health, attackStrength)
        {
            BackPack = new List<ILuggable>();
        }
        internal int X { get; set; }

        internal int Y { get; set; }

        internal List<ILuggable> BackPack { get; set; }

        internal override string Message(Character opponent)
        {
            return "player message";
        }

        internal override void Fight(Character opponent)
        {
            opponent.Health -= AttackStrength;
        }
    }
}
