using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultilingualWebsite.Models;

using Microsoft.Extensions.Localization;
using System.Reflection;

namespace MultilingualWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> localizer;
        private readonly IStringLocalizer<SharedResource> sharedLocalizer;

        public HomeController(IStringLocalizer<HomeController> localizer, IStringLocalizer<SharedResource> sharedLocalizer, IStringLocalizerFactory factory)
        {
            this.localizer = localizer;
            this.sharedLocalizer = sharedLocalizer;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = localizer["これは日本語"];
            ViewData["Common"] = sharedLocalizer["これは共通の日本語"];

            return View();
        }

        public IActionResult About()
        {
            //ViewData["Message"] = "Your application description page.";
            ViewData["Message"] = localizer["これは日本語"];

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
