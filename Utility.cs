using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiberiTreeGen
{
    public class Utility
    {
        static Random random;

        public Utility(int randomSeed)
        {
            Utility.random = new Random(randomSeed);
        }

        public static int randomInRange(int min, int max)
        {
            return Utility.random.Next(min, max + 1);
        }
    }
}
