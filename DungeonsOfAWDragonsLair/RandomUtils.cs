using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfAWDragonsLair
{
    static class RandomUtils
    {
        private static Random rndGen;

        static RandomUtils()
        {
            rndGen = new Random();
        }

        public static int RandomNumber(int min, int max)
        {
            return rndGen.Next(min, max);
        }

    }
}
