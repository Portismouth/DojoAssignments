using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//
using LoginRegistration.Models;


namespace LoginRegistration.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;
 
        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }
 
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // Because I like using try statements.. Check if user id is in session, if it is set the User's information to a ViewBag variable. if any of that fails just load the index page
            try
            {
                int? id = HttpContext.Session.GetInt32("UserId");
                List<Dictionary<string, object>> User = _dbConnector.Query($"SELECT * FROM users WHERE id = {id}");
                ViewBag.User = User[0];
                return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(User newUser)
        {
            if(ModelState.IsValid)
            {
                //Handle success, if any of it failes it hits teh catch statement and returns you to the page with email already taken error
                try 
                {
                    //ADDS TO DATABASE IF SUCCESS
                    _dbConnector.Execute($"INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) VALUES ('{newUser.FirstName}', '{newUser.LastName}', '{newUser.Email}', '{newUser.Password}', NOW(), NOW())");

                    //Grabs the newly registered user
                    List<Dictionary<string, object>> CurrentUser = _dbConnector.Query($"SELECT * FROM users WHERE email = '{newUser.Email}'");

                    //Saves the User ID in session
                    var user = CurrentUser[0];
                    HttpContext.Session.SetInt32("UserId", (int)user["id"]);
                    return RedirectToAction("Index");

                }
                catch
                {
                    ModelState.AddModelError("Email", "Email Address already taken");
                    ViewBag.errors = ModelState.Values;
                    return View("Index");
                }
                
            }
            //if form isnt valid
            ViewBag.errors = ModelState.Values;
            return View("Index");
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string email, string password)
        {
            // Manually validating for login because I couldn't figure out the model validation for this
            try 
            {
                //Grabs the user by email
                List<Dictionary<string, object>> CurrentUser = _dbConnector.Query($"SELECT * FROM users WHERE email = '{email}'");

                // User is who we just grabbed out of DB, checking if email and password match
                var user = CurrentUser[0];
                if ((string)user["email"] == email && (string)user["password"] == password)
                {
                    HttpContext.Session.SetInt32("UserId", (int)user["id"]);
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Invalid Login";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                //This hits if the DB Query was not valid
                TempData["error"] = "Not a valid email";
                return RedirectToAction("Index");
            }         
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }   
}
