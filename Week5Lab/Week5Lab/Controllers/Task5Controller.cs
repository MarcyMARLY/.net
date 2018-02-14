using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Week5Lab.Models;

namespace Week5Lab.Controllers
{
    public class Task5Controller : Controller
    {
        static readonly string marketPath = "AppData/markets.csv";
        static readonly string productPath = "AppData/products.csv";
        static readonly string productInfoPath = "AppData/productInfo.csv";
        static readonly string orderPath = "AppData/orders.csv";
      
       
        public IActionResult Task5()
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
        public IActionResult Buy(int ID, int ProductID)
        {
            ViewData["ID"] = ID;
            ViewData["ProductID"] = ProductID;
            return View();
        }
        [HttpPost]
        public IActionResult Answer(int ProductID,int ID)
        {
            int ProduxtAmount = int.Parse(Request.Form["Amount"].ToString());

            var productStore = new ProductStore() { Path = productPath };
            var orderStore = new OrderStore() { Path = orderPath };

            var productList = productStore.GetCollection();
            var orderList = orderStore.GetCollection();

            ViewData["ID"] = ID;
            ViewData["ProductID"] = ProductID;
            if (productList.Where(x => x.Id == ProductID).First().Amount < ProduxtAmount)
            {
                ViewData["Answer"] = "Error. We don't have so many items";
            }
            else
            {
                var c = productList.Where(x => x.Id == ProductID).First();
               
                
                    int val = orderList.Where(x => x.Id == ProductID).Sum(x => x.Amount);
                    if (val + ProduxtAmount > c.Amount)
                    {
                        ViewData["Answer"] = "Error. We don't have so many items";
                    }
                    else
                    {
                    orderStore.WriteData(c.Id, c.Name, c.Price,ProduxtAmount);
                        ViewData["Answer"] = "Ok. Your request is in process";
                    }
                
            }
            return View();
        }
    }
}