using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public static class Randomizer
    {
        public static Random rnd = new Random();


        public static int GetRndPositiveInt(int num)
        {
            return rnd.Next(num);
        }
        public static int GetCardID()
        {
            return rnd.Next(1,52);
        }
    }
}
