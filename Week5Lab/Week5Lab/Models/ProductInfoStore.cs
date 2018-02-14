using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Week5Lab.Models
{
    class ProductInfoStore:IStore<ProductInfo>
    {
        private List<ProductInfo> _cachedCollection;
        public string Path { get; set; }

        public List<ProductInfo> GetCollection()
        {
            var data = File.ReadAllLines(Path);
            _cachedCollection = data
                .Skip(1)
                .Select(x => ConvertItem(x))
                .ToList();
            return _cachedCollection;
        }
        public ProductInfo ConvertItem(string item)
        {
            var itemList = item.Split(';');
            return new ProductInfo {
                Id = Convert.ToInt32(itemList[0]),
                Definition = itemList[2],
                Parameter = itemList[1],
                ProductId = Convert.ToInt32(itemList[3])
            };

        }
    }
}
