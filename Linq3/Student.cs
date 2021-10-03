using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq3
{
    class Student
    {
        public int Id { get; set; }
        public string PersonName { get; set; }   
        public List<Course> Courses { get; set; }

        public Student()
        {
            Courses = new List<Course>();
        }
    }
}
