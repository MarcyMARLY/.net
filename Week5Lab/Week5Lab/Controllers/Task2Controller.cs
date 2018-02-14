using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Week5Lab.Models;

namespace Week5Lab.Controllers
{
    
    public class Task2Controller : Controller
    {
        static readonly string marketPath = "AppData/markets.csv";
        static readonly string productPath = "AppData/products.csv";
        static readonly string productInfoPath = "AppData/productInfo.csv";

        public IActionResult Task2()
        {
            Console.WriteLine("Aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            var marketStore = new MarketStore() { Path = marketPath };
            var productStore = new ProductStore() { Path = productPath };
            var productInfoStore = new ProductInfoStore() { Path = productInfoPath };

            var marketList = marketStore.GetCollection();
            var productList = productStore.GetCollection();
            var productInfoList = productInfoStore.GetCollection();

            return View(marketList);
        }
        
        public IActionResult Test(int ID)
        {
            Console.WriteLine("Aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            var marketStore = new MarketStore() { Path = marketPath };
            var productStore = new ProductStore() { Path = productPath };
            var productInfoStore = new ProductInfoStore() { Path = productInfoPath };

            var marketList = marketStore.GetCollection();
            var productList = productStore.GetCollection().Where(x => x.MarketId == ID);
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
                 });

            ViewData["ID"] = ID;
            return View(temp1);
        }
        public IActionResult SortedByPrice(int ID)
        {
            Console.WriteLine("Aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            var marketStore = new MarketStore() { Path = marketPath };
            var productStore = new ProductStore() { Path = productPath };
            var productInfoStore = new ProductInfoStore() { Path = productInfoPath };

            var marketList = marketStore.GetCollection();
            var productList = productStore.GetCollection().Where(x => x.MarketId == ID);
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
                 });

            ViewData["ID"] = ID;
            return View(temp1.OrderBy(x => x.ProductPrice));
        }
        public IActionResult SortedByAmount(int ID)
        {
           
            var marketStore = new MarketStore() { Path = marketPath };
            var productStore = new ProductStore() { Path = productPath };
            var productInfoStore = new ProductInfoStore() { Path = productInfoPath };

            var marketList = marketStore.GetCollection();
            var productList = productStore.GetCollection().Where(x => x.MarketId == ID);
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
                 });

            ViewData["ID"] = ID;
            return View(temp1.OrderBy(x => x.ProductAmount));
        }
    }
}