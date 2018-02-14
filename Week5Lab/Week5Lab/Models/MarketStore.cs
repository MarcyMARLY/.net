using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Week5Lab.Models
{

    class MarketStore:IStore<Market>
    {
        private List<Market> _cachedCollection;
        public string Path { get;set; }
        public List<Market> GetCollection() {
            if(_cachedCollection == null)
            {
                var data = File.ReadAllLines(Path);
                _cachedCollection = data
                    .Skip(1)
                    .Select(x => ConvertItem(x))
                    .ToList();
            }
            return _cachedCollection;

        }
        public Market ConvertItem(string item)
        {
            var ItemList = item.Split(';');
            return new Market()
            {
                ID = Convert.ToInt32(ItemList[0]),
                Name = ItemList[1],
                Rating = Convert.ToInt32(ItemList[2])
            };
        }

    }
}
