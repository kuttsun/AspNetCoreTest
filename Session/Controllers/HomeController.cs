using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using Session.Models;

namespace Session.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            TempData["TempData"] = "Index";
            HttpContext.Session.SetString("Session", "Index");

            var person = new Person()
            {
                Name = "Index",
                Age = 10
            };

            TempData.Set(nameof(Person), person);
            HttpContext.Session.Set(nameof(Person), person);

            return View();
        }

        public IActionResult About()
        {
            var people = new List<Person>();
            ViewData["TempData"] = TempData["TempData"];
            ViewData["Session"] = HttpContext.Session.GetString("Session");
            people.Add(TempData.Get<Person>(nameof(Person)));
            people.Add(HttpContext.Session.Get<Person>(nameof(Person)));

            return View(people);
        }

        public IActionResult Contact()
        {
            TempData["TempData"] = "Contact";
            HttpContext.Session.SetString("Session", "Contact");

            var person = new Person()
            {
                Name = "Contact",
                Age = 20
            };

            TempData.Set(nameof(Person), person);
            HttpContext.Session.Set(nameof(Person), person);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }

    public static class TempDataDictionaryExtensions
    {
        public static void Set<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonConvert.SerializeObject(value);
        }

        public static T Get<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            tempData.TryGetValue(key, out var obj);
            return obj == null ? default(T) : JsonConvert.DeserializeObject<T>(obj.ToString());
        }
    }
}
