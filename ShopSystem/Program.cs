using System;

namespace ShopSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");


            Coffee cof1 = new Coffee();
            cof1.id = 1;
            cof1.price = 3;

            Tea tea1 = new Tea();
            tea1.id  = 1;
            tea1.price = 2;

            

 			Order order1 = new Order();
            order1.CoffeeList.Add(cof1);
            order1.TeaList.Add(tea1);

            Client client1 = new Client();
            client1.id = 1;
            client1.cash = 20;
            client1.orders.Add(order1);


            System system = new System();
            system.Clients.Add(client1);
        }

    }
}
