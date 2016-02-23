using DungeonsOfAWLib;
using Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters
{
    class Gremlin : Monster
    {
        internal Gremlin(string name, int health, int attackStrength, int weight, ConsoleColor color) : base(name, health, attackStrength, weight, color)
        {
        }

        internal override void Fight(Character opponent)
        {
            if ((opponent.AttackStrength / (AttackStrength) >= 2))
            {
                Health = 0;
                AttackStrength = 0;
            }
            else
                base.Fight(opponent);
        }

        internal override string Message(Character opponent)
        {
            if ((opponent.AttackStrength / (AttackStrength) >= 2))
            {
                return @"You encountered an aggresive Gremlin.. SPLAT! ..and struck it down with your sword.";
            }
            else
            {
                return @"You encountered a squemish Gremlin, and it immediately scurried down a hole. 
(Press enter to continue)";
            }
        }

    }
}
