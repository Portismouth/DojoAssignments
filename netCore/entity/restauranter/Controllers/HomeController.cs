using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//
using Microsoft.EntityFrameworkCore;
using restauranter.Models;
using System.Linq;
//
using System.Globalization;

namespace restauranter.Controllers
{
    public class HomeController : Controller
    {
        private Context _context;
 
        public HomeController(Context context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [Route("review")]
        public IActionResult Review(Review addReview)
        {
            if(ModelState.IsValid)
            {
                // This stuff is useless and is not needed but it works so I am not taking it out -- JK I need this stuff for jQuery UI that I have installed for the datepicker..
                DateTime result;
                result = DateTime.ParseExact(addReview.date, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                string newresult = result.ToString();
                // End of useless stuff
                Review NewReview = new Review
                {
                    reviewname = addReview.reviewname,
                    restaurantname = addReview.restaurantname,
                    review = addReview.review,
                    date = newresult,
                    rating = addReview.rating,
                };

                _context.Add(NewReview);
                _context.SaveChanges();

                return RedirectToAction("Reviews" , "Reviews");
            }
            //if form isnt valid
            ViewBag.errors = ModelState.Values;
            return View("Index");
        }
    }
}
