using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace Linq4
{
    class Program
    {





        public static void ex1()
        {
            var arr = new int[] { 2, 4, 5, 1, 5, 2, 3 };
            var v = (from item in arr
                     orderby item
                     where item % 2 == 0
                     select item);

            foreach (var item2 in v)
            {
                Console.WriteLine(item2);
            }
        }

        public static void ex2()
        {
            var arr = new int[] { 2, 4, 5, 1, 5, 2, 3 };
            var v = (from item in arr
                     where item % 2 == 0
                     orderby item
                     select item);

            foreach (var item2 in v)
            {
                Console.WriteLine(item2);
            }
        }





        private static void ex3()
        {
            ex1();
            ex2();
            Stopwatch s = new Stopwatch();

            s.Reset();
            s.Start();
            for (int i = 0; i < 1000; i++)
                ex1();
            s.Stop();
            long ex1_time = s.ElapsedMilliseconds;

            s.Reset();
            s.Start();
            for (int i = 0; i < 1000; i++)
                ex2();
            s.Stop();
            long ex2_time = s.ElapsedMilliseconds;

            Console.Clear();
            Console.WriteLine("ex1: {0} milliseconds", ex1_time);
            Console.WriteLine("ex2: {0} milliseconds", ex2_time);
        }


private static bool complexFunc()
{
    for (int i = 0; i < 1000000; i++) ;
    return true;
}

public static void ex4()
{
    IEnumerable<int> numbersA = Enumerable.Range(0, 100);
    
    Stopwatch s = new Stopwatch();
    s.Reset();
    s.Start();

    var result =
        from a in numbersA
        where complexFunc()
        select a;
   

    foreach (var item in result)
    {
        if (item % 10 == 0)
            Console.WriteLine();
        Console.Write("{0,-5}", item);
    }
    s.Stop();
    Console.WriteLine("\nex4: {0} milliseconds", s.ElapsedMilliseconds);
}


public static void ex5()
{

    IEnumerable<int> numbersA = Enumerable.Range(0, 100);
           
    Stopwatch s = new Stopwatch();
    s.Reset();
    s.Start();

    var result =
        from a in numbersA.AsParallel()
        where complexFunc()
        select a;

    foreach (var item in result)
    {
        if (item % 10 == 0)
            Console.WriteLine();
        Console.Write("{0,-5}", item);
    }
    s.Stop();
    Console.WriteLine("\nex5: {0} milliseconds", s.ElapsedMilliseconds);
}

public static void ex6()
{

    IEnumerable<int> numbersA = Enumerable.Range(0, 100);
            
    Stopwatch s = new Stopwatch();
    s.Reset();
    s.Start();

    var result =
        from a in numbersA.AsParallel().AsOrdered()
        where complexFunc()
        select a;

    foreach (var item in result)
    {
        if (item % 10 == 0)
            Console.WriteLine();
        Console.Write("{0,-5}", item);
    }
    s.Stop();
    Console.WriteLine("\nex6: {0} milliseconds", s.ElapsedMilliseconds);
}

        public static void ex7()
        {
            ex4();
            ex5();
            ex6();
            Stopwatch s = new Stopwatch();

            s.Reset();
            s.Start();
            for (int i = 0; i < 10; i++)
                ex4();
            s.Stop();
            long ex4_time = s.ElapsedMilliseconds;

            s.Reset();
            s.Start();
            for (int i = 0; i < 10; i++)
                ex5();
            s.Stop();
            long ex5_time = s.ElapsedMilliseconds;

            s.Reset();
            s.Start();
            for (int i = 0; i < 10; i++)
                ex6();
            s.Stop();
            long ex6_time = s.ElapsedMilliseconds;

            Console.Clear();
            Console.WriteLine("ex4: {0} milliseconds", ex4_time);
            Console.WriteLine("ex5: {0} milliseconds", ex5_time);
            Console.WriteLine("ex6: {0} milliseconds", ex6_time);
        }



static void Main(string[] args)
{
    ex7();
}


    }
}
