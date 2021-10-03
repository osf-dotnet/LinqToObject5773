using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq3
{
    public enum Department { computer,  mathematics,  physics}
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Department department { get; set; }
    }
}
