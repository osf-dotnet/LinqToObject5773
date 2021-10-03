using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Linq3
{



    class Program
    {
        public static void groupEx1()
        {
            int[] numbers = { 5, 4, 12, 33, 91, 8, 6, 7, 22, 0 };

            IEnumerable<IGrouping<int, int>> result = from n in numbers
                                                      group n by n % 2 into g
                                                      select g;

            foreach (IGrouping<int, int> g in result)
            {
                switch (g.Key)
                {
                    case 1:
                        Console.WriteLine("Odd Number:");
                        foreach (int n in g)
                            Console.Write("{0}, ", n);
                        Console.WriteLine("\n");
                        break;

                    case 0:
                        Console.WriteLine("Even Number:");
                        foreach (int n in g)
                            Console.Write("{0}, ", n);
                        Console.WriteLine("\n");
                        break;
                }
            }
        }
        public static void groupEx2()
        {
            string[] words = 
    { 
        "blueberry",
        "chimpanzee",
        "abacus",
        "banana",
        "apple",
        "cheese" 
    };

            var wordGroups =
                from w in words
                group w by w[0] into g
                select new { FirstLetter = g.Key, Words = g };

            foreach (var item in wordGroups)
            {
                Console.WriteLine("'{0}':", item.FirstLetter);
                foreach (var w in item.Words)
                    Console.WriteLine(w);
                Console.WriteLine();
            }
        }
      
        
        static void Main(string[] args)
        {

            groupEx1();

        }
    }
}
