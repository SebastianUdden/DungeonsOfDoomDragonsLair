using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfAWDragonsLair
{
    static class RandomUtils
    {
        public static Random RndGen { get; set; }

        static RandomUtils()
        {
            RndGen = new Random();
        }

        public static int RandomNumber(int min, int max)
        {
            return RndGen.Next(min, max);
        }

    }
}
