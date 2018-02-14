using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Week6Lab.Models;

namespace Week6Lab.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Calc calc) {
            ModelState.Clear();
            switch (calc.operationType)
            {
                case Operation.Addition:
                    calc.Result = calc.Number1 + calc.Number2;
                    break;
                case Operation.Substraction:
                    calc.Result = calc.Number1 - calc.Number2;
                    break;
                case Operation.Multiplication:
                    calc.Result = calc.Number1 * calc.Number2;
                    break;
                case Operation.Division:
                    calc.Result = calc.Number1 / calc.Number2;
                    break;


            }

            return View(calc);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
