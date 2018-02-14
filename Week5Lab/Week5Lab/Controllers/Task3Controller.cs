using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Week5Lab.Models;

namespace Week5Lab.Controllers
{
    public class Task3Controller : Controller
    {
        static readonly string marketPath = "AppData/markets.csv";
        static readonly string productPath = "AppData/products.csv";
        static readonly string productInfoPath = "AppData/productInfo.csv";

        
        public IActionResult Task3()
        {
            var productStore = new ProductStore() { Path = productPath };
            var productInfoStore = new ProductInfoStore() { Path = productInfoPath };

            var productList = productStore.GetCollection();
            var productInfoList = productInfoStore.GetCollection();

            var temp1 = productList.Join(productInfoList, tempItem => tempItem.Id,
                info => info.ProductId,

                (tempItem, info) =>
                new ProductAndProductInfo
                {
                    ProductId = tempItem.Id,
                    ProductName = tempItem.Name,
                    ProductPrice = tempItem.Price,
                    ProductAmount = tempItem.Amount,
                    ProductDeliveryPeriod = tempItem.DeliveryPeriod,
                    ProductMarketId = tempItem.MarketId,
                    ProductInfoId = info.Id,
                    ProductInfoParameter = info.Parameter,
                    ProductInfoDefinition = info.Definition,
                    ProductInfoProductId = info.ProductId
                }).Where(x=>(x.ProductInfoParameter=="Rating"&&int.Parse(x.ProductInfoDefinition)<6));

            return View(temp1);
        }
    }
}