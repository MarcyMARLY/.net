using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Week5Lab.Models;
namespace Week5Lab.Controllers
{
    public class TestController : Controller
    {
       
        static readonly string orderPath = "AppData/orders.csv";
        public IActionResult Test()
        {
            var orderStore = new OrderStore() { Path = orderPath };
            var orderList = orderStore.GetCollection();
            var val = orderList.Sum(x => x.Amount*x.Price);
            var orderCopy = orderList.GroupBy(x => x.Id).Select(y => new Order
            {
                Id = y.First().Id,
                Name = y.First().Name,
                Price = y.First().Price,
                Amount = y.Key
            });
            ViewData["TotalAmount"] = val;
            return View(orderList);
        }
    }
}