using System;
using System.Collections.Generic;
using System.Text;

namespace Week1Lab.Model
{
    class Order
    {
        private static int OrderId = 1;
        private int OrdersId;

        public List<Coffee> CoffeeList = new List<Coffee>();
        public List<Tea> TeaList = new List<Tea>();

        public Order()
        {
            OrdersId = OrderId++;
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
