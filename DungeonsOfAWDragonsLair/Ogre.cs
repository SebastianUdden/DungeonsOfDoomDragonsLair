﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfAWDragonsLair
{
    class Ogre : Monster
    {

        public Ogre(string name, int health, int attackstrength) : base(name, health, attackstrength)
        {

        }

        public override string Message(Character opponent)
        {
            return @"You encountered a twoheaded Ogre, strike it down twice 
(Press enter to continue)";
        }

    }
}
