using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Week5Lab.Models
{
    public class OrderStore : IStore<Order>
    {
        private List<Order> _cachedCollection;
        public string Path { get; set; }
        public List<Order> GetCollection()
        {
            if (_cachedCollection == null)
            {
                var data = File.ReadAllLines(Path);
                _cachedCollection = data
                    .Select(x => ConvertItem(x))
                    .ToList();
            }
            return _cachedCollection;

        }
        public Order ConvertItem(string item)
        {
            var ItemList = item.Split(';');
            return new Order()
            {
                Id = Convert.ToInt32(ItemList[0]),
                Name = ItemList[1],
                Price = Convert.ToInt32(ItemList[2]),
                Amount = Convert.ToInt32(ItemList[3])
            };
        }
        public void WriteData(int Id, string Name, int Price, int Amount)
        {
            string res = Id.ToString() + ";" + Name + ";" + Price.ToString() + ";" + Amount.ToString();
            using (StreamWriter sw = File.AppendText(Path))
            {
                sw.WriteLine(res); 
            }
        }
    }
}
