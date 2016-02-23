using DungeonsOfAWLib;
using Elements;
using Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters
{
    internal abstract class Character : GameObject
    {
        internal Character(string name, int health, int attackStrength) : base(name)
        {
            Health = health;
            AttackStrength = attackStrength;
        }

        internal int Health { get; set; }
        internal int AttackStrength{ get; set; }

        internal abstract string Message(Character opponent);

        internal abstract void Fight(Character opponent);

    }
}
