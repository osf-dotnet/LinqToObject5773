using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq5
{
    class Program
    {
        public static void Linq92()
        {
            double[] doubles = { 1,2,3,4 };

            double product = doubles.Aggregate((runningProduct, nextFactor) => runningProduct * nextFactor);

            Console.WriteLine("Total product of all numbers: {0}", product);
        }

        static void Main(string[] args)
        {
            Linq92();
        }
    }
}
