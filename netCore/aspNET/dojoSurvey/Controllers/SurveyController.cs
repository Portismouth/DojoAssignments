using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace dojoSurvey.Controllers
{
    public class SurveyController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("index");
        }

        [HttpPost]
        [Route("result")]
        public IActionResult Method(string name, string location, string language, string message)
        {
            // Do something with form input
            ViewBag.Name = name;
            ViewBag.Location = location;
            ViewBag.Language = language;
            ViewBag.Message = message;
            return View("result");
        }
    }
}