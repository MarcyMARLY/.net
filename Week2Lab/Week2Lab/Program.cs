using System;
using System.Linq;
using Week2Lab.Models;
using System.Collections.Generic;
using System.IO;

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
                if (k == "5")
                {
                    val = true;
                    Step5();
                    Console.WriteLine("Which step you want to see?");
                    k = Console.ReadLine();
                }
                if (k != "1" && k != "2" && k != "3" && k != "4" && k != "5") 
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
        public static void Step5()
        {

            var marketStore = new MarketStore() { Path = marketPath };
            var productStore = new ProductStore() { Path = productPath };
            var productInfoStore = new ProductInfoStore() { Path = productInfoPath };

            var marketList = marketStore.GetCollection();
            var productList = productStore.GetCollection();
            var productInfoList = productInfoStore.GetCollection();



            /*foreach (var item in marketList)
            {
                item.products = productList.Where(x => x.MarketId == item.ID).ToList();
            }
            foreach (var item in productList)
            {
                item.productInfos = productInfoList.Where(x => x.ProductId == item.Id).OrderBy(x => x.Parameter).ToList();
            }*/

            Console.WriteLine("====================================");
            foreach( var market in marketList)
            {
                Console.WriteLine("Market {0}:{1}", market.ID, market.Name);
            }
            Console.WriteLine();
            Console.WriteLine("Please, choose the number of the market:");
            string k = Console.ReadLine();

            var chProductList = productList.Where(x => x.MarketId == int.Parse(k)).ToList(); 
            
            foreach(var item in chProductList)
            {
                Console.WriteLine("Product {0}, Name {1}, Price {2}, TotalAmount {3}", item.Id, item.Name, item.Price, item.Amount);
            }
            Console.WriteLine();
            List<string> lines = new List<string>();
            /*lines.Add("ffff");
            File.WriteAllLines(@"AppData/test.csv", lines);*/
            
            bool chh = true;
            double totalAmount = 0;
            while (chh == true)
            {
                Console.WriteLine("For quiting enter 'q', for continuing enter 'c'");
                string ams = Console.ReadLine();
                if (ams == "q")
                {
                    File.WriteAllLines(@"AppData/test.csv", lines);
                    Console.WriteLine("The check");
                    Console.WriteLine("====================================");
                    var data = File.ReadAllLines(@"AppData/test.csv");

                    foreach(var item in data)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("=========");
                    Console.WriteLine("Total: {0}", totalAmount);
                    Console.WriteLine();
                    chh = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Please, choose the product");
                    string prName = Console.ReadLine();
                    bool exist = false;
                    foreach(var item in chProductList)
                    {
                        if (item.Id == int.Parse(prName))
                        {

                            //lines.Add(prName + ";");
                            //lines.Add(item.Name + ";");
                            Console.WriteLine("Please, enter the amount of the product");
                            string prNum = Console.ReadLine();

                            if (int.Parse(prNum) > item.Amount)
                            {
                                Console.WriteLine("No such amount of the product. Please choose less than or equal {0}", item.Amount);
                                prNum = Console.ReadLine();
                                //lines.Add(prNum + ";");
                                item.Amount -= int.Parse(prNum);
                                double summ = int.Parse(prNum) * item.Price;
                                totalAmount += summ;
                                lines.Add(prName + ";" + item.Name + ";"+ prNum + ";"+ summ.ToString()+";");
                                //lines.Add("\n");
                            }
                            else
                            {
                                //lines.Add(prNum + ";");
                                double summ = int.Parse(prNum) * item.Price;
                                item.Amount -= int.Parse(prNum);
                                totalAmount += summ;
                                lines.Add(prName + ";" + item.Name + ";" + prNum + ";" + summ.ToString() + ";");
                                lines.Add("\n");
                            }
                            exist = true;
                        }
                    }
                    if(exist == false)
                    {
                        Console.WriteLine("No such product for this market");
                    }                    
                }
            }
        }
    }
    
}
