using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Collections;

namespace LinqToObject5772
{
    class A { }
    class B : A { }
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<int> Grades { get; set; }
    }

    class MyClass
    {
        readonly int x;

        public int X
        {
            get { return x; }
            //   set { x = value; }
        }


    }

    class Program
    {
        // where
        public static void ex1()
        {
            IEnumerable<int> arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Func<int, bool> func = myFunc;
            IEnumerable<int> v = arr.Where(func);

            foreach (var item in v)
                Console.WriteLine(item);
        }
        static bool myFunc(int x)
        {
            return x % 2 == 0;
        }

        public static void ex1_b()
        {
            IEnumerable<int> arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var v = arr.Where(t => t % 2 == 0);

            foreach (var item in v)
                Console.WriteLine(item);
        }

        // select
        static void ex2()
        {
            IEnumerable<int> arr1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            IEnumerable<string> arr2 = arr1.Select(item => "number is " + item);
            
            foreach (var item in arr2)
                Console.WriteLine(item);
        }

        // where and select
        public static void ex3()
        {
            IEnumerable<int> arr1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var arr2 = arr1.Where(i => i % 2 == 0).
                Select(item => item * 2);
            foreach (var item in arr2)
                Console.WriteLine(item);
        }

        // linq query
        public static void ex4()
        {
            IEnumerable<int> arr1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            IEnumerable<int> arr2 = from int item in arr1
                                    where item % 2 == 0
                                    select item * 2;

            foreach (var item in arr2)
                Console.WriteLine(item);
        }
        static void ex4_1()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int x = 2;
            var v = from item in arr
                    where item % x == 0
                    select item;
            foreach (var item in v)
                Console.WriteLine(item);
        }
        static void ex4_2()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int x = 2;
            var v = from item in arr
                    where item % x == 0
                    select item;
            x = 3;
            foreach (var item2 in v)
            {
                Console.WriteLine(item2);
            }
        }

        public static void ex5()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] strings = { "zero", "one", "two", "three", "four", 
                           "five", "six", "seven", "eight", "nine" };

            var textNums =
                from n in numbers
                select strings[n];

            Console.WriteLine("Number strings:");
            foreach (var s in textNums)
                Console.WriteLine(s);
        }
        public static void ex6()
        {
            string[] strings = { "oshRi", "ezra", "eliEzer" };
            var v = from item in strings
                    select item.ToUpper();
            foreach (var s in v)
                Console.WriteLine(s);
        }
        public static void ex7()
        {
            string[] strings = { "oshRi", "ezra", "eliEzer" };
            var v = from item in strings
                    select new { Upper = item.ToUpper(), Lower = item.ToLower() };

            foreach (var s in v)
                Console.WriteLine("Uppercase: {0,-10}, Lowercase: {1}", s.Upper, s.Lower);
        }
        public static void ex8()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numsInPlace = numbers.Select((num, index) => new { Num = num, InPlace = (num == index) });

            Console.WriteLine("Number: In-place?");
            foreach (var n in numsInPlace)
                Console.WriteLine("{0}: {1}", n.Num, n.InPlace);

        }

        public static void ex9()
        {
            int[] numbers = { 1, 4, 1, 3, 9, 2, 5 };
            int sum = numbers.Sum();

            Console.WriteLine(sum);
        }

        public static void ex10()
        {
            string[] words = { "dot net", "oshri", "java" };
            int sum = words.Sum(item => item.Length);

            Console.WriteLine(sum);
        }

        public static void ex11()
        {
            int[] numbers = { 1, 4, 1, 3, 9, 2, 5 };
            Console.WriteLine("int[] numbers = { 1, 4, 1, 3, 9, 2, 5 }");
            Console.WriteLine("numbers.Sum:      " + numbers.Sum());
            Console.WriteLine("umbers.Average(): " + numbers.Average());
            Console.WriteLine("numbers.Max():    " + numbers.Max());
            Console.WriteLine("numbers.Min():    " + numbers.Min());


            Console.WriteLine();

            string[] words = { "dot net", "oshri", "java" };
            Console.WriteLine("string[] words = { \"dot net\", \"oshri\", \"java\" }");
            Console.WriteLine("words.Sum:      " + words.Sum(item => item.Length));
            Console.WriteLine("words.Average(): " + words.Average(item => item.Length));
            Console.WriteLine("words.Max():    " + words.Max());
            Console.WriteLine("words.Min():    " + words.Min());
        }


        // nesting query
        public static void ex12()
        {
            int[] numbersA = { 1, 2, 3, 4, 5, 14, 22 };
            int[] numbersB = { 22, 3, 12, 14, 3, 13, 2 };

            var result = from num in numbersA
                         from num2 in numbersB
                         where num == num2
                         select num;

            foreach (var item in result)
                Console.Write("{0}, ", item);
            Console.WriteLine();
        }

        //Distinct
        public static void ex13()
        {
            int[] numbersA = { 1, 2, 3, 4, 5, 14, 22 };
            int[] numbersB = { 22, 3, 12, 14, 3, 13, 2 };

            var result = from num in numbersA
                         from num2 in numbersB
                         where num == num2
                         select num;

            foreach (var item in result)
                Console.Write("{0}, ", item);
            Console.WriteLine();
        }

        // nesting query
        static int count = 0;
private static int digitCount(int num)
{
    int i = 1;
    while ((num /= 10) != 0)
    {
        i++;
        count++;
    }
    return i;
}
        public static void ex14()
        {
            count = 0;
            int[] numbersA = { 1, 22, 333, 4444, 55555, 666666, 7777777 };
            int[] numbersB = { 1, 3, 5 };

            var result =
                from a in numbersA
                from b in numbersB
                where digitCount(a) == b
                select a;

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("while count: " + count);
        }

        // nesting query and let
        public static void ex15()
        {
            count = 0;
            int[] numbersA = { 1, 22, 333, 4444, 55555, 666666, 7777777 };
            int[] numbersB = { 1, 3, 5 };

            var result =
                from a in numbersA
                let  temp = digitCount(a)
                from b in numbersB
                where temp == b
                select a;

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(count);
        }



        static void Main(string[] args)
        {


            ex14();

        }
    }
}
