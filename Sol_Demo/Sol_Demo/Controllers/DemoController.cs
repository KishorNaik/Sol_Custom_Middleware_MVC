using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sol_Demo.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {

            ViewBag.Data = HttpContext.Items["SecretKey"];

            return View();
        }
    }
}