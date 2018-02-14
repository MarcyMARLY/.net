using System;
using System.Collections.Generic;
using System.Text;

namespace Week5Lab.Models
{
   public class Market
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public List<Product> products { get; set; }

    }
}
