using System;
using System.Collections.Generic;
using System.Text;
using Week1Lab.Model;

namespace Week1Lab
{
    class Calculation
    {
        
            private double CoffeeCnt = 0;
            private double TeaCnt = 0;

            public double TCproportion(Client client1)
            {
                foreach (Order o in client1.Orders)
                {
                    foreach (Coffee cof in o.CoffeeList)
                    {
                        CoffeeCnt++;
                    }
                    foreach (Tea tea in o.TeaList)
                    {
                        TeaCnt++;
                    }
                }
                return TeaCnt / CoffeeCnt;
            }
            public void OrderDescription(Order order)
            {
                CoffeeCollection cc = new CoffeeCollection();
                TeaCollection tc = new TeaCollection();


                int coffeeCnt = 0;
                int teaCnt = 0;
                for (int i = 0; i < order.CoffeeList.Count; i++)
                {
                    Coffee c = order.CoffeeList[i];

                    if (cc.CoffeeCollecionList.Contains(c) == false)
                    {
                        coffeeCnt++;
                    }
                }
                for (int i = 0; i < order.TeaList.Count; i++)
                {
                    Tea t = order.TeaList[i];
                    if (tc.TeaCollectionList.Contains(t) == false)
                    {
                        teaCnt++;
                    }
                }
                //Console.WriteLine("{0},{1}", order.CoffeeList.Count, order.TeaList.Count);
                Console.WriteLine("Order number = {0}, number of ordered coffee cups = {1}, number of ordered tea cups = {2}", order.GetOrdersId(), coffeeCnt, teaCnt);
            }
            public void CheckClient(Client client, Order o, out double total, out bool ok )
            {

                total = 0;
                //double total = 0;
                double coffeTotal = 0;
                foreach (Coffee c in o.CoffeeList)
                {
                    coffeTotal += c.CoffeePrice;
                }
                double teaTotal = 0;
                foreach (Tea c in o.TeaList)
                {
                    teaTotal += c.TeaPrice;
                }
                total = total + coffeTotal + teaTotal;

                if (client.balance >= total)
                {
                 ok = true;
                    Console.WriteLine("Client{0} can pay for order {1}", client.GetClientID(), o.GetOrdersId());
                }
                else
                {
                 ok = false;
                    Console.WriteLine("Client{0} cannot pay for order {1}, because client's balance {2} and order cost {3} ", client.GetClientID(), o.GetOrdersId(), client.balance, total);
                }
            
        }
        public void ValidateOrder(Client client, Order order)
        {
            CheckClient(client, order, out double total, out bool ok);
            if (ok == true)
            {
                client.balance -= total;
                client.Orders.Remove(order);
            }
        }
    }
}
