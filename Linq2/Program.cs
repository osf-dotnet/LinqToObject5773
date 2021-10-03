using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq2
{
    class Program
    {


        static List<Student> initList()
        {
            return new List<Student>
     {
        new Student{Name = "oshri", Id = 1, Grades = new List<int>{45,83,80},  Age = 29} ,
        new Student{Name = "ezra",  Id = 2, Grades = new List<int>{80,90,80},  Age = 26} ,
        new Student{Name = "yoav",  Id = 3, Grades = new List<int>{90,90,85},  Age = 29} ,
        new Student{Name = "dan",   Id = 4, Grades = new List<int>{100,75,80}, Age = 29} ,
        new Student{Name = "ron",   Id = 5, Grades = new List<int>{40,80,80},  Age = 34} ,
        new Student{Name = "orit",  Id = 6, Grades = new List<int>{50,13,80},  Age = 20} ,
        new Student{Name = "tom",   Id = 7, Grades = new List<int>{55,100,80}, Age = 29} ,
        new Student{Name = "david", Id = 8, Grades = new List<int>{90,70,80},  Age = 22} ,
        new Student{Name = "dor",   Id = 9, Grades = new List<int>{100,60,80}, Age = 22} ,    
     };
        }

        static void ex1()
        {
            var v = from item in initList()
                    where item.Grades.Average() > 80
                    select item;

            foreach (var item in v)
                Console.WriteLine("name: {0,-10} id: {1,-5}  average: {2}",
                    item.Name,
                    item.Id, item.Grades.Average());
        }
        static void ex1_b()
        {
            var v = from item in initList()
                    let average = item.Grades.Average()
                    where average > 80
                    select new { Name = item.Name, Id = item.Id, Average = average };

            foreach (var item in v)
                Console.WriteLine("name: {0,-10} id: {1,-5}  average: {2}",
                    item.Name,
                    item.Id, item.Average);
        }

        static void ex2()
        {
            List<Student> list = initList();
            double x = list.Average(s => s.Age);
            Console.WriteLine(x);
        }
        static void ex3()
        {
            List<Student> list = initList();
            double allAverageGrades = list.Average(student => student.Grades.Average());
            Console.WriteLine(allAverageGrades);
        }
        static void ex4()
        {
            var v = from item in initList()
                    let average = item.Grades.Average()
                    where average < 80
                    orderby item.Id
                    select new { Name = item.Name, Id = item.Id, Average = average };

            foreach (var item in v)
                Console.WriteLine("name: {0,-10} id: {1,-5}  average: {2}", item.Name,
                    item.Id, item.Average);
        }

        static void ex5()
        {
            var v = from item in initList()
                    let average = item.Grades.Average()
                    where average < 80
                    orderby item.Name descending
                    select new { Name = item.Name, Id = item.Id, Average = average };

            foreach (var item in v)
                Console.WriteLine("name: {0,-10} id: {1,-5}  average: {2}", item.Name,
                    item.Id, item.Average);
        }
        static void ex6()
        {
            var v = from item in initList()
                    orderby item.Age, item.Name
                    select new { Name = item.Name, Age = item.Age };

            foreach (var item in v)
                Console.WriteLine("{0,-5} {1}", item.Age, item.Name);
        }
       
        static void Main(string[] args)
        {
            ex4();

        }
    }
}

