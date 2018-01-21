using System;
using System.Collections.Generic;
using System.Text;

namespace Week2Lab.Models
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public int DeliveryPeriod { get; set; }
        public int MarketId { get; set; }
        public List<ProductInfo> productInfos { get; set; }
    }
}
