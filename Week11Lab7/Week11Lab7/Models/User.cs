using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Week11Lab7.Model
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public int mark { get; set; }
        public string category { get; set; }
    }
}
