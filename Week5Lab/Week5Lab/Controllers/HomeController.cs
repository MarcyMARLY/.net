using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Week5Lab.Models;

namespace Week5Lab.Controllers
{
    public class HomeController : Controller
    {
        static readonly string marketPath = "AppData/markets.csv";
        static readonly string productPath = "AppData/products.csv";
        static readonly string productInfoPath = "AppData/productInfo.csv";
        public IEnumerable<Market> MarketList { get; set; }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Task1()
        {
            var marketStore = new MarketStore() { Path = marketPath };
            var productStore = new ProductStore() { Path = productPath };
            var productInfoStore = new ProductInfoStore() { Path = productInfoPath };

            var marketList = marketStore.GetCollection();
            var productList = productStore.GetCollection();
            var productInfoList = productInfoStore.GetCollection();
            var temp = from product in productList
                       join market in marketList on product.MarketId equals market.ID
                       select new
                       {
                           MarketID = market.ID,
                           MarketName = market.Name,
                           MarketRating = market.Rating,
                           ProductId = product.Id,
                           ProductName = product.Name,
                           ProductPrice = product.Price,
                           ProductAmount = product.Amount,
                           ProductDeliveryPeriod = product.DeliveryPeriod,
                           ProductMarketId = product.MarketId
                       };
            var temp1 = temp.Join(productInfoList, tempItem => tempItem.ProductId,
                 info => info.ProductId,

                 (tempItem, info) =>
                 new Complete
                 {
                     MarketID = tempItem.MarketID,
                     MarketName = tempItem.MarketName,
                     MarketRating = tempItem.MarketRating,
                     ProductId = tempItem.ProductId,
                     ProductName = tempItem.ProductName,
                     ProductPrice = tempItem.ProductPrice,
                     ProductAmount = tempItem.ProductAmount,
                     ProductDeliveryPeriod = tempItem.ProductDeliveryPeriod,
                     ProductMarketId = tempItem.ProductMarketId,
                     ProductInfoId = info.Id,
                     ProductInfoParameter = info.Parameter,
                     ProductInfoDefinition = info.Definition,
                     ProductInfoProductId = info.ProductId
                 });


            return View(temp1);
        }
        

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
