using System;
using System.Collections.Generic;
using System.Text;

namespace Week1Lab.Model
{
    class Order
    {
        private static int OrderId = 1;
        private int OrdersId;

        public List<Coffee> CoffeeList { get; set; }
        public List<Tea> TeaList { get; set; }

        public Order()
        {
            OrdersId = OrderId++;
            CoffeeList = new List<Coffee>(); 
            TeaList = new List<Tea>();
        }

        public int GetOrdersId()
        {
            return OrdersId;
        }
        public void SetOrdersId(int ID) {
            OrdersId = ID;
        }
    }
}
