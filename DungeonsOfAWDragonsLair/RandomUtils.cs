﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfAWDragonsLair
{
    static class RandomUtils
    {
        static Random rndgen;

        static RandomUtils()
        {
            rndgen = new Random();
        }

        public static int RandomNumber(int min, int max)
        {
            return rndgen.Next(min, max);
        }

    }
}
