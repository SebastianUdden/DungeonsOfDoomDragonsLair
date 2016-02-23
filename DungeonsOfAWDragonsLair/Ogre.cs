using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfAWDragonsLair
{
    class Ogre : Monster
    {

        public Ogre(string name, int health, int attackstrength, int weight) : base(name, health, attackstrength, weight)
        {

        }

        public override string Message(Character opponent)
        {
            return @"You encountered a twoheaded Ogre, strike it down twice 
(Press enter to continue)";
        }

    }
}
