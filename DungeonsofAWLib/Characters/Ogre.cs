using DungeonsOfAWLib;
using Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Characters
{
    class Ogre : Monster
    {

        internal Ogre(string name, int health, int attackstrength, int weight, ConsoleColor color) : base(name, health, attackstrength, weight, color)
        {

        }

        internal override string Message(Character opponent)
        {
            return @"You encountered a twoheaded Ogre, strike it down twice 
(Press enter to continue)";
        }

    }
}
