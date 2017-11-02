using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace callingCard.Controllers
{
    public class CallingCard : Controller
    {
        [HttpGet]
        [Route("")]
        public string Index()
        {
            return "Hello World";
        }

        [HttpGet]
        [Route("{first}/{last}/{age}/{favorite}")]
        public JsonResult Name(string first, string last, int age, string favorite)
        {
            var person = new {
                FirstName = first,
                LastName = last,
                Age = age,
                color = favorite
            };
            return Json(person);
        }
    }
}