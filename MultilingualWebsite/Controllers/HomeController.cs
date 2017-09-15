using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultilingualWebsite.Models;

using Microsoft.Extensions.Localization;

namespace MultilingualWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> localizer;

        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            this.localizer = localizer;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = localizer["hoge"];

            return View();
        }

        public IActionResult About()
        {
            //ViewData["Message"] = "Your application description page.";
            ViewData["Message"] = localizer["hoge"];

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
