using System;
using System.Collections.Generic;
using System.Text;

namespace Week1Lab.Model
{
    class CoffeeCollection
    {
        public List<Coffee> CoffeeCollecionList { get; set; }
        public CoffeeCollection() {

            CoffeeCollecionList = new List<Coffee>();
        }
    }
}
