using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestLibrary1.Model;


namespace TestLibrary1
{
    public class Provider
    {
        public string Path { get; set; }
        private List<Car> result;
        public List<Car> getCollection()
        {
            Console.WriteLine("dddd");
            if (!File.Exists(Path))
            {
                Console.WriteLine("Error, file does not exist");
            }
            if (result == null)
            {
                var data = File.ReadAllLines(Path);
                result = data
                    .Skip(1)
                    .Select(x => ConvertItem(x))
                    .ToList();

            }
            return result;
        }
        public Car ConvertItem(string item)
        {
            var ItemList = item.Split(';');
            Console.Write(ItemList.Length);
            return new Car()
            {
                Name = ItemList[0],
                year = Convert.ToInt32(ItemList[1]),
                price = Convert.ToInt32(ItemList[2])

            };

        }
        public List<Car> GetCarsByYear(string comp, int value){
            List<Car> res = new List<Car>();
            //value=4;
            if(comp==">"){
                res = result.Where(x=>x.year > value).OrderBy(x=>x.year).ToList();
            }
            if(comp=="<"){
                res = result.Where(x=>x.year < value).OrderBy(x=>x.year).ToList();
            }
            if(comp=="="){
                res = result.Where(x=>x.year == value).OrderBy(x=>x.year).ToList(); 
}
            int cnt = 0;
            foreach (var item in res)
            {
                cnt++;
            }
            if (cnt == 0)
            {
                Console.WriteLine("It's no results");
            }
            return res;
        }
        public List<Car> FindCarByName(string name){
            List<Car> res = new List<Car>();
            res = result.Where(x=>x.Name == name).OrderBy(x=>x.year).ToList();
            int cnt =0;
            foreach(var item in res)
            {
                cnt++;
            }
            if (cnt == 0)
            {
                Console.WriteLine("It's no results");
            }
            return res;
        }
        public List<Car> GetCarsByPrice(int value1, int value2){
            List<Car> res = new List<Car>();
            res= result.Where(x=>(x.price>value1 && x.price<value2)).OrderBy(x=>x.price).ToList();
            int cnt = 0;
            foreach (var item in res)
            {
                cnt++;
            }
            if (cnt == 0)
            {
                Console.WriteLine("It's no results");
            }
            return res;
        }
        public void PrintList(List<Car> res){
            Console.WriteLine("========================================");
            foreach(var car in res){
                Console.WriteLine(string.Format("Car Name : {0}, Year : {1}, Price : {2}",
                    car.Name,
                    car.year,
                    car.price
                    ));
            }
        }
        //add car
    }
}
