using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week5Lab.Models
{
    public class ProductAndProductInfo
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public int ProductDeliveryPeriod { get; set; }
        public int ProductMarketId { get; set; }
        public int ProductInfoId { get; set; }
        public string ProductInfoParameter { get; set; }
        public string ProductInfoDefinition { get; set; }
        public int ProductInfoProductId { get; set; }
    }
}
