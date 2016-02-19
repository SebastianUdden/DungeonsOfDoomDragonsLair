using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfAWDragonsLair
{
    abstract class Character : GameObject
    {
        public Character(string name, int health, int attackStrength) : base(name)
        {
            Health = health;
            AttackStrength = attackStrength;
        }

        public int Health { get; set; }
        public int AttackStrength{ get; set; }
    }
}
