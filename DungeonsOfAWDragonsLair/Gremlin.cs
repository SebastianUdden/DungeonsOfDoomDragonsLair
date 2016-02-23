using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfAWDragonsLair
{
    class Gremlin : Monster
    {
        public Gremlin(string name, int health, int attackStrength, int weight) : base(name, health, attackStrength, weight)
        {
        }

        public override void Fight(Character opponent)
        {
            if ((opponent.AttackStrength / (AttackStrength) >= 2))
            {
                Health = 0;
                AttackStrength = 0;
            }
            else
                base.Fight(opponent);
        }

        public override string Message(Character opponent)
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
