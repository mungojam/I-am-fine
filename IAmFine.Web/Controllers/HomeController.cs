using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IAmFine.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserPage()
        {
            return View();
        }

        public IActionResult ManagerPage()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
