using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi__Demo.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BatchCode { get; set; }
        public int Marks
        {
            get; set;
        }
    }
}
