using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;

namespace ajax.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Dictionary<string, object>> allNotes = DbConnector.Query("SELECT * FROM Notes");
            ViewBag.notes = allNotes;
            return View();
        }
        [HttpPost]
        [Route("")]
        public List<Dictionary<string, object>> Note(string name)
        {
            DbConnector.Execute($"INSERT INTO Notes (name) VALUES ('{name}')");
            List<Dictionary<string, object>> allNotes = DbConnector.Query("SELECT * FROM Notes");
            return allNotes;
        }

        [HttpPost]
        [Route("/delete/{id}")]
        public int Delete(int id)
        {
            DbConnector.Execute($"DELETE FROM Notes WHERE id = {id}");
            return id;
        }

        [HttpPost]
        [Route("/content/{id}")]
        public string Content(string content, int id)
        {
            DbConnector.Execute($"UPDATE Notes SET content = '{content}' WHERE id = {id}");
            return content;
        }
    }
}
