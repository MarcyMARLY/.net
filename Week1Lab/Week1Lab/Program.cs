using System;
using Week1Lab.Model;

namespace Week1Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Coffee capuchino = new Coffee();
            capuchino.CoffeeType = "capuchino";
            capuchino.CoffeePrice = 4;
            Coffee expresso = new Coffee();
            expresso.CoffeeType = "expresso";
            expresso.CoffeePrice = 3;
            Coffee rissotto = new Coffee();
            rissotto.CoffeeType = "rissotto";
            rissotto.CoffeePrice = 3;

            CoffeeCollection cc = new CoffeeCollection();
            cc.CoffeeCollecionList.Add(capuchino);
            cc.CoffeeCollecionList.Add(expresso);
            cc.CoffeeCollecionList.Add(rissotto);

            Tea ulun = new Tea();
            ulun.TeaType = "ulun";
            ulun.TeaPrice = 6;
            Tea green = new Tea();
            green.TeaType = "green";
            green.TeaPrice = 2;
            Tea black = new Tea();
            black.TeaType = "black";
            black.TeaPrice = 8;

            TeaCollection tc = new TeaCollection();
            tc.TeaCollectionList.Add(ulun);
            tc.TeaCollectionList.Add(green);
            tc.TeaCollectionList.Add(black);


            Order order1 = new Order();
            order1.CoffeeList.Add(cc.CoffeeCollecionList[0]);
            order1.CoffeeList.Add(cc.CoffeeCollecionList[0]);
            order1.CoffeeList.Add(cc.CoffeeCollecionList[1]);

            order1.TeaList.Add(tc.TeaCollectionList[2]);
            order1.TeaList.Add(tc.TeaCollectionList[1]);
            Order order2 = new Order();
            order2.CoffeeList.Add(cc.CoffeeCollecionList[2]);
            order2.CoffeeList.Add(cc.CoffeeCollecionList[0]);
            order2.CoffeeList.Add(cc.CoffeeCollecionList[1]);
            order2.CoffeeList.Add(cc.CoffeeCollecionList[1]);

            order2.TeaList.Add(tc.TeaCollectionList[1]);
            order2.TeaList.Add(tc.TeaCollectionList[1]);

            Client client1 = new Client();
            client1.Orders.Add(order1);
            client1.Orders.Add(order2);
            client1.balance = 3;
            Client client2 = new Client();
            client2.Orders.Add(order1);
            client2.Orders.Add(order2);
            client2.balance = 33;

            ShopSystem shopSystem = new ShopSystem();
            shopSystem.Clients.Add(client1);
            shopSystem.Clients.Add(client2);

            Console.WriteLine("Clients' number in system equals = {0}",shopSystem.Clients.Count);
            Calculation calc = new Calculation();
            Console.WriteLine("For client {0} proportion of Tea to Coffee = {1}", client1.GetClientID(), calc.TCproportion(shopSystem.Clients[0]));
            Console.WriteLine("For client {0} number of orders = {1}", shopSystem.Clients[0].GetClientID(), shopSystem.Clients[0].Orders.Count);
            foreach (Order o in client1.Orders)
            {
                calc.OrderDescription(o);
            }
            calc.CheckClient(client1, client1.Orders[0], out double total, out bool ok);

            Console.WriteLine("CoffeeCollection has Capacity {0}", cc.CoffeeCollecionList.Capacity);
            foreach(Coffee c in cc.CoffeeCollecionList)
            {
                Console.WriteLine("Coffee name {0}, Coffee price {1}", c.CoffeeType, c.CoffeePrice);
            }
            Console.WriteLine("TeaCollection has Capacity {0}", tc.TeaCollectionList.Capacity);
            foreach (Tea t in tc.TeaCollectionList)
            {
                Console.WriteLine("Tea name {0}, Tea price {1}", t.TeaType, t.TeaPrice);
            }
            calc.ValidateOrder(client1, order1);
            Console.WriteLine("For client {0} number of orders = {1}", shopSystem.Clients[1].GetClientID(), shopSystem.Clients[1].Orders.Count);
            calc.ValidateOrder(client2, order1);
            Console.WriteLine("For client {0} number of orders = {1}", shopSystem.Clients[1].GetClientID(), shopSystem.Clients[1].Orders.Count);

            Console.ReadLine();
        }


    }

}
