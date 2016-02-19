using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfAWDragonsLair
{
    class Monster : Character
    {
        public Monster(string name, int health, int attackStrength) : base(name, health, attackStrength)
        {

        }

        public override void Fight(Character opponent)
        {
            opponent.Health -= AttackStrength;

            //Health -= opponent.AttackStrength; 
        }

        public override string Message()
        {
            return "monster message";
        }
    }
}
