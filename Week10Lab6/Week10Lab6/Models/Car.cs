using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week10Lab6.Models
{
    public class Car
    {
        public int id { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public string color { get; set; }
        public string country { get; set; }
        public int ownerId { get; set; }
    }
}
