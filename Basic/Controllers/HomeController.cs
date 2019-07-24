using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Basic.Models;

namespace Basic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return View(new SampleViewModel());
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostTest(SampleViewModel vm)
        {
            return View(vm);
        }

        [HttpPost]
        public IActionResult PostTest2(string[] names, int[] ages)
        {
            var vm = new SampleViewModel();
            foreach (var (v, i) in names.Select((v, i) => (v, i)))
            {
                vm.Persons.Add(new Person { Name = v, Age = ages[i] });
            }
            return View("PostTest", vm);
        }

        [HttpPost]
        public IActionResult PostTest3(Dictionary<int, string> dict)
        {
            var vm = new SampleViewModel();
            foreach (var (v, i) in dict.Select((v, i) => (v, i)))
            {
                vm.Persons.Add(new Person { Name = v.Value, Age = v.Key });
            }
            return View("PostTest", vm);
        }
    }
}
