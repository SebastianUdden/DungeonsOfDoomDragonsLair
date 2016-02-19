using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfAWDragonsLair
{
    class Gremlin : Monster
    {

        public Gremlin(string name, int health, int attackStrength) : base(name, health, attackStrength)
        {

        }

        public override void Fight(Character opponent)
        {

            //opponent.AttackStrength >= AttackStrength * 2 ? Health = 0 : base.Fight(opponent);

            if ((opponent.AttackStrength / (AttackStrength) >= 2))
            {
                Health = 0;
                AttackStrength = 0;
            }
            else
                base.Fight(opponent);
        }

    }
}
