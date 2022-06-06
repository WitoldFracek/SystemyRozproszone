using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClientMVC.Controllers
{
    public class MyDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
