using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;
using System.Linq;

namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {
        private Context _context;
 
        public WeddingController(Context context)
        {
            _context = context;
        }

        //Current datetime
        public DateTime now()
        {
            DateTime now = DateTime.Now;
            return now;
        }

        public void CheckLoggedIn()
        {
            int? id = HttpContext.Session.GetInt32("LOGGED_IN_USER");
            User LoggedIn = _context.Users.SingleOrDefault(user => user.userid == id);
            ViewBag.User = LoggedIn;
        }
        // GET: /Home/
        [HttpGet]
        [Route("dashboard")]
        public IActionResult Index()
        {
            try
            {
                CheckLoggedIn();
                List<Wedding> AllWeddings = _context.Weddings.Include(w => w.guests).ThenInclude(g => g.user).ToList();
                ViewBag.Weddings = AllWeddings;
                return View();
            }
            catch
            {
                return View();
            }
            
        }


        // CREATE WEDDING POST ROUTE AND VIEW ROUTE
        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            CheckLoggedIn();
            return View();
        }
        [HttpPost]
        [Route("create")]
        public IActionResult CreateWedding(WeddingRegister model)
        {
            if(ModelState.IsValid)
            {
                Wedding NewWedding = new Wedding
                {
                    wedderone = model.wedderone,
                    weddertwo = model.weddertwo,
                    date = model.date,
                    address = model.address,
                    createdat = now()
                };
                _context.Weddings.Add(NewWedding);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.errors = ModelState.Values;
            return View("Create");
        }

        //VIEW WEDDING
        [HttpGet]
        [Route("wedding/{id}")]
        public IActionResult Wedding(int id)
        {
            CheckLoggedIn();
            Wedding viewWedding = _context.Weddings.Include(w => w.guests).ThenInclude(g => g.user).SingleOrDefault(w => w.weddingid == id);
            ViewBag.wedding = viewWedding;
            return View();
        }

        [HttpGet]
        [Route("rsvp/{WeddingID}")]
        public IActionResult rsvp(int WeddingID)
        {
            int? id = HttpContext.Session.GetInt32("LOGGED_IN_USER");
            User LoggedIn = _context.Users.SingleOrDefault(user => user.userid == id);
            ViewBag.User = LoggedIn;
            Wedding curWedding = _context.Weddings.SingleOrDefault(w => w.weddingid == WeddingID);
            Guest newGuest = new Guest
            {
                userid = (int)id,
                user = LoggedIn,
                weddingid = WeddingID,
                wedding = curWedding
            };
            _context.Guests.Add(newGuest);
            _context.SaveChanges();
            return RedirectToAction("Wedding", new {id = WeddingID});
        }
        [HttpGet]
        [Route("unrsvp/{WeddingID}/{UserID}")]
        public IActionResult unrsvp(int WeddingID, int UserID)
        {
            try
            {
                Guest retrievedGuest = _context.Guests.SingleOrDefault(g => g.userid == UserID && g.weddingid == WeddingID );
                _context.Guests.Remove(retrievedGuest);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index", "Home");
            }
            
            
        }
    }
}
