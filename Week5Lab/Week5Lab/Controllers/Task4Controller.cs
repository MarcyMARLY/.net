using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Week5Lab.Models;

namespace Week5Lab.Controllers
{
    public class Task4Controller : Controller
    {
        static readonly string marketPath = "AppData/markets.csv";
        static readonly string productPath = "AppData/products.csv";
        static readonly string productInfoPath = "AppData/productInfo.csv";

       
        public IActionResult Task4()
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
                var xx = marketList.Select(m => new SpecialMarket
                {
                    Name = m.Name,
                    ID = m.ID,
                    Rating = m.Rating,
                    Average = temp1.Where(t => (t.MarketID == m.ID && t.ProductInfoParameter == "Rating")).Average(z => int.Parse(z.ProductInfoDefinition))
                }).Where(x => x.Rating < x.Average);
            return View(xx);
        }
    }
}