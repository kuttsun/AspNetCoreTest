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
        readonly IStringLocalizer<HomeController> localizer;
        readonly IStringLocalizer<SharedResource> sharedLocalizer;
        readonly IStringLocalizer<MessageResource> messageLocalizer;

        public HomeController(IStringLocalizer<HomeController> localizer, IStringLocalizer<SharedResource> sharedLocalizer, IStringLocalizer<MessageResource> messageLocalizer, IStringLocalizerFactory factory)
        {
            this.localizer = localizer;
            this.sharedLocalizer = sharedLocalizer;
            this.messageLocalizer = messageLocalizer;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = localizer["Hello"];
            ViewData["test"] = localizer["Test"];
            ViewData["Common"] = sharedLocalizer["share1"] + messageLocalizer["Mes1"];

            return View();
        }

        public IActionResult About()
        {
            //ViewData["Message"] = "Your application description page.";
            ViewData["Message"] = localizer["Hello"];

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
