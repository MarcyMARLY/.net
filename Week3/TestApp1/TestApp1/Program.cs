using System;
using TestLibrary1;
using TestLibrary1.Model;
using System.Collections.Generic;
namespace TestApp1
{
    class Program
    {
        static string path = "Cars.csv";
        static void Main(string[] args)
        {
            Provider p = new Provider() { Path = path };
            var carList = p.getCollection();
            p.PrintList(carList);
            bool ch = true;
            while (ch == true)
            {
                Console.WriteLine("Choose the option :\n 1 - Find car by model; \n 2 - Find car by year; \n 3 - Find car by price;");
                string val = Console.ReadLine();
                if (val == "1")
                {
                    Console.WriteLine("Enter the model name:");
                    string name = Console.ReadLine();
                    var ans = p.FindCarByName(name);

                    //p.PrintList(ans);
                    PrintList(ans);



                }
                else if (val == "2")
                {
                    Console.WriteLine("Enter the comparator sign:");
                    string comp = Console.ReadLine();
                    Console.WriteLine("Enter the year:");
                    string year = Console.ReadLine();
                    var ans = p.GetCarsByYear(comp, int.Parse(year));
                    PrintList(ans);
                }
                else if (val == "3")
                {
                    Console.WriteLine("Enter the lowest price:");
                    int val1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the highest price:");
                    int val2 = int.Parse(Console.ReadLine());
                    PrintList(p.GetCarsByPrice(val1, val2));
                }
                else
                {
                    ch = false;
                }
            }


        }
        public static void PrintList(List<Car> ans)
        {
            foreach (var car in ans)
            {
                Console.WriteLine(string.Format("Car Name : {0}, Year : {1}, Price : {2}",
                    car.Name,
                    car.year,
                    car.price
            ));
            }
        }
    }
}
