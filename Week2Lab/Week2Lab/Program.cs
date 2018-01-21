using System;
using System.Linq;
using Week2Lab.Models;

namespace Week2Lab
{
    class Program
    {
        static readonly string marketPath = "AppData/markets.csv";
        static readonly string productPath = "AppData/products.csv";
        static readonly string productInfoPath = "AppData/productInfo.csv";
        static void Main(string[] args)
        {
            
            Console.WriteLine("Which step you want to see?");
            string k = Console.ReadLine();
            bool val = true;
            while (val == true)
            {
                if (k == "1")
                {
                    val = true;
                    Step1();
                    Console.WriteLine("Which step you want to see?");
                     k = Console.ReadLine();
                }
                if(k == "2")
                {
                    val = true;
                    Step2();
                    Console.WriteLine("Which step you want to see?");
                    k = Console.ReadLine();

                }
                if(k == "3")
                {
                    val = true;
                    Step3();
                    Console.WriteLine("Which step you want to see?");
                    k = Console.ReadLine();
                }
                if(k == "4")
                {
                    val = true;
                    Step4();
                    Console.WriteLine("Which step you want to see?");
                    k = Console.ReadLine();
                }
                if(k != "1" && k != "2" && k!= "3" && k!= "4")
                {
                    val = false;
                }

            }


            

            //Console.ReadLine();
        }
        public static void Step1()
        {
            //Step1

            var marketStore = new MarketStore() { Path = marketPath };
            var productStore = new ProductStore() { Path = productPath };
            var productInfoStore = new ProductInfoStore() { Path = productInfoPath };

            var marketList = marketStore.GetCollection();
            var productList = productStore.GetCollection();
            var productInfoList = productInfoStore.GetCollection();

            foreach (var item in marketList)
            {
                item.products = productList.Where(x => x.MarketId == item.ID).ToList();
            }
            foreach (var item in productList)
            {
                item.productInfos = productInfoList.Where(x => x.ProductId == item.Id).ToList();
            }

            Console.WriteLine("Step 1 \n");
            foreach (var market in marketList)
            {
                Console.WriteLine("================================");

                Console.WriteLine(string.Format("{0}) {1}; Rating: {2}; Product Price Sum: {3}",
                   market.ID,
                   market.Name,
                   market.Rating,
                   market.products.Sum(x => x.Price)));



                foreach (var prod in market.products)
                {
                    Console.WriteLine();
                    Console.WriteLine("Product ");

                    var prodTemplate = "{0} | {1} | {2} | {3} | {4}";

                    Console.WriteLine(string.Format(prodTemplate,
                    "Id",
                    "Name",
                    "Price",
                    "Amount",
                    "Delivery Perion (days)"));

                    Console.WriteLine(string.Format(prodTemplate,
                        prod.Id,
                        prod.Name,
                        prod.Price,
                        prod.Amount,
                        prod.DeliveryPeriod));
                    var prodInfoTemp = "{0} | {1} | {2}  ";
                    Console.WriteLine();
                    Console.WriteLine("Product Info");
                    Console.WriteLine(string.Format(prodInfoTemp, "Id", "Parameter", "Definition"));

                    foreach (var info in prod.productInfos)
                    {
                        Console.WriteLine(string.Format(prodInfoTemp,
                            info.Id,
                            info.Parameter,
                            info.Definition
                            ));
                    }
                }

            }

        }
        public static void Step2()
        {

            //Step2
            var marketStore = new MarketStore() { Path = marketPath };
            var productStore = new ProductStore() { Path = productPath };
            var productInfoStore = new ProductInfoStore() { Path = productInfoPath };

            var marketList = marketStore.GetCollection();
            var productList = productStore.GetCollection();
            var productInfoList = productInfoStore.GetCollection();

            foreach (var item in marketList)
            {
                item.products = productList.Where(x => x.MarketId == item.ID).ToList();
            }
           

            Console.WriteLine("Step 2 \n");

            foreach (var market in marketList)
            {
                Console.WriteLine("================================");

                Console.WriteLine(string.Format("{0}) {1}; Rating: {2}; Product Price Sum: {3}",
                   market.ID,
                   market.Name,
                   market.Rating,
                   market.products.Sum(x => (x.Price * x.Amount))));
                foreach (var prod in market.products)
                {
                    Console.WriteLine();
                    Console.WriteLine("Product ");

                    var prodTemplate = "{0} | {1} | {2} | {3} | {4}";

                    Console.WriteLine(string.Format(prodTemplate,
                    "Id",
                    "Name",
                    "Price",
                    "Amount",
                    "Delivery Perion (days)"));

                    Console.WriteLine(string.Format(prodTemplate,
                        prod.Id,
                        prod.Name,
                        prod.Price,
                        prod.Amount,
                        prod.DeliveryPeriod));
                }


            }

            Console.WriteLine("\n Sorted by price \n");

            foreach (var item in marketList)
            {
                item.products = productList.Where(x => x.MarketId == item.ID).OrderBy(x => x.Price).ToList();
            }
            foreach (var market in marketList)
            {
                Console.WriteLine("================================");

                Console.WriteLine(string.Format("{0}) {1}; Rating: {2}; Product Price Sum: {3}",
                   market.ID,
                   market.Name,
                   market.Rating,
                   market.products.Sum(x => (x.Price * x.Amount))));
                foreach (var prod in market.products)
                {
                    Console.WriteLine();
                    Console.WriteLine("Product ");

                    var prodTemplate = "{0} | {1} | {2} | {3} | {4}";

                    Console.WriteLine(string.Format(prodTemplate,
                    "Id",
                    "Name",
                    "Price",
                    "Amount",
                    "Delivery Perion (days)"));

                    Console.WriteLine(string.Format(prodTemplate,
                        prod.Id,
                        prod.Name,
                        prod.Price,
                        prod.Amount,
                        prod.DeliveryPeriod));
                }
            }

            Console.WriteLine("\n Sorted by amount \n");
            foreach (var item in marketList)
            {
                item.products = productList.Where(x => x.MarketId == item.ID).OrderBy(x => x.Amount).ToList();
            }
            foreach (var market in marketList)
            {
                Console.WriteLine("================================");

                Console.WriteLine(string.Format("{0}) {1}; Rating: {2}; Product Price Sum: {3}",
                   market.ID,
                   market.Name,
                   market.Rating,
                   market.products.Sum(x => (x.Price * x.Amount))));
                foreach (var prod in market.products)
                {
                    Console.WriteLine();
                    Console.WriteLine("Product ");

                    var prodTemplate = "{0} | {1} | {2} | {3} | {4}";

                    Console.WriteLine(string.Format(prodTemplate,
                    "Id",
                    "Name",
                    "Price",
                    "Amount",
                    "Delivery Perion (days)"));

                    Console.WriteLine(string.Format(prodTemplate,
                        prod.Id,
                        prod.Name,
                        prod.Price,
                        prod.Amount,
                        prod.DeliveryPeriod));
                }
            }
        
        }
        public static void Step3()
        {
            var marketStore = new MarketStore() { Path = marketPath };
            var productStore = new ProductStore() { Path = productPath };
            var productInfoStore = new ProductInfoStore() { Path = productInfoPath };

            var marketList = marketStore.GetCollection();
            var productList = productStore.GetCollection();
            var productInfoList = productInfoStore.GetCollection();




            foreach (var item in productList)
            {
                item.productInfos = productInfoList.Where(x => x.ProductId == item.Id).OrderBy(x => x.Parameter).ToList();
            }
            var temp = from product in productList join market in marketList on product.MarketId equals market.ID
                       select new { Id = product.Id, Name = product.Name, Price = product.Price,
                           Amount = product.Amount, DeliveryPeriod = product.DeliveryPeriod,
                           Rating = market.Rating, productInfos  = product.productInfos  };

           

            foreach (var prod in temp)
            {
                Console.WriteLine();
                Console.WriteLine("Product ");

                if(prod.Rating < 6)
                {
                    Console.Write("*");
                }

                var prodTemplate = "{0} | {1} | {2} | {3} | {4} | {5}";

                Console.WriteLine(string.Format(prodTemplate,
                "Id",
                "Name",
                "Price",
                "Amount",
                "Delivery Perion (days)",
                "Rating"));

                Console.WriteLine(string.Format(prodTemplate,
                    prod.Id,
                    prod.Name,
                    prod.Price,
                    prod.Amount,
                    prod.DeliveryPeriod,
                    prod.Rating));
                var prodInfoTemp = "{0} | {1} | {2}  ";
                Console.WriteLine();
                Console.WriteLine("Product Info");
                Console.WriteLine(string.Format(prodInfoTemp, "Id", "Parameter", "Definition"));

                foreach (var info in prod.productInfos)
                {
                    Console.WriteLine(string.Format(prodInfoTemp,
                        info.Id,
                        info.Parameter,
                        info.Definition
                        ));
                }
            }
        }
        public static void Step4()
        {
            var marketStore = new MarketStore() { Path = marketPath };
            var productStore = new ProductStore() { Path = productPath };
            var productInfoStore = new ProductInfoStore() { Path = productInfoPath };

            var marketList = marketStore.GetCollection();
            var productList = productStore.GetCollection();
            var productInfoList = productInfoStore.GetCollection();



            foreach (var item in marketList)
            {
                item.products = productList.Where(x => x.MarketId == item.ID).ToList();
            }
            foreach (var item in productList)
            {
                item.productInfos = productInfoList.Where(x => x.ProductId == item.Id).OrderBy(x => x.Parameter).ToList();
            }
            var temp = from product in productList
                       join market in marketList on product.MarketId equals market.ID
                       select new
                       {
                           Id = product.Id,
                           Name = product.Name,
                           Price = product.Price,
                           Amount = product.Amount,
                           DeliveryPeriod = product.DeliveryPeriod,
                           Rating = market.Rating,
                           productInfos = product.productInfos
                       };
            double average = temp.Average(x=>x.Rating);

            foreach (var market in marketList)
            {
                Console.WriteLine("================================");
                if (market.Rating < average)
                {
                    Console.Write("*");
                }

                Console.WriteLine(string.Format("{0}) {1}; Rating: {2}; Product Price Sum: {3}",
                   market.ID,
                   market.Name,
                   market.Rating,
                   market.products.Sum(x => x.Price)));



                foreach (var prod in market.products)
                {
                    Console.WriteLine();
                    Console.WriteLine("Product ");

                    var prodTemplate = "{0} | {1} | {2} | {3} | {4}";

                    Console.WriteLine(string.Format(prodTemplate,
                    "Id",
                    "Name",
                    "Price",
                    "Amount",
                    "Delivery Perion (days)"));

                    Console.WriteLine(string.Format(prodTemplate,
                        prod.Id,
                        prod.Name,
                        prod.Price,
                        prod.Amount,
                        prod.DeliveryPeriod));
                    var prodInfoTemp = "{0} | {1} | {2}  ";
                    Console.WriteLine();
                    Console.WriteLine("Product Info");
                    Console.WriteLine(string.Format(prodInfoTemp, "Id", "Parameter", "Definition"));

                    foreach (var info in prod.productInfos)
                    {
                        Console.WriteLine(string.Format(prodInfoTemp,
                            info.Id,
                            info.Parameter,
                            info.Definition
                            ));
                    }
                }

            }


        }
    }
    
}
