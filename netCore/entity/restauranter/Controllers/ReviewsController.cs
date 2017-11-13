using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//
using Microsoft.EntityFrameworkCore;
using restauranter.Models;
using System.Linq;

namespace restauranter.Controllers
{
    public class ReviewsController : Controller
    {
        private Context _context;
 
        public ReviewsController(Context context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("reviews")]
        public IActionResult Reviews()
        {
            List<Review> AllReviews = _context.reviews.OrderByDescending(r => r.id).ToList();
            return View(AllReviews);
        }
    }
}
