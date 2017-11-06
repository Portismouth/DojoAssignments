using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace quotingDojo.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/quotes")]
        public IActionResult Quotes()
        {
            List<Dictionary<string, object>> AllQuotes = DbConnector.Query("SELECT * FROM quotes ORDER BY created_at DESC");
            ViewBag.quotes = AllQuotes;
            Console.WriteLine(AllQuotes);
            return View("Quotes");
        }

        [HttpPost]
        [Route("/quotes")]
        public IActionResult postQuote(string name, string quote)
        {
            DbConnector.Execute($"INSERT INTO quotes (name, quote, created_at) VALUES ('{name}', '{quote}', NOW())");
            return Redirect("/quotes");
        }
    }
}
