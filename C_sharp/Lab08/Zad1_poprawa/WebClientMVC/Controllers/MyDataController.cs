using InfoPresenter;
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
            string myData = Client.GetMyData();
            return View(new MyData { ServiceData = myData, LocalData = MyData.InfoString() });
        }
    }
}
