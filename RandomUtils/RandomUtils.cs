using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class RandomUtils
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
