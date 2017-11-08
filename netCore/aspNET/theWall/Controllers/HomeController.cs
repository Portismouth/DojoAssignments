using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//
using theWall.Models;

namespace theWall.Controllers
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
                    return RedirectToAction("Index", "Wall");

                }
                catch
                {
                    // This catches if the email address is already taken in database and adds a custom error to email
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
        public IActionResult Login(Login newlogin)
        {
            if(ModelState.IsValid)
            {
                //Handle success, if any of it failes it hits teh catch statement and returns you to the page with email already taken error
                try 
                {

                    //Grabs the newly registered user
                    List<Dictionary<string, object>> CurrentUser = _dbConnector.Query($"SELECT * FROM users WHERE email = '{newlogin.LoginEmail}'");

                    //Saves the User ID in session if password is equal to password in database
                    var user = CurrentUser[0];
                    if ((string)user["password"] == newlogin.LoginPassword)
                    {
                        HttpContext.Session.SetInt32("UserId", (int)user["id"]);
                        return RedirectToAction("Index", "Wall");
                    }
                    // Else hits if password isn't correct and adds custom error to login password
                    else
                    {
                        ModelState.AddModelError("LoginPassword", "Invalid Password");
                        ViewBag.errors = ModelState.Values;
                        return View("Index");
                    }

                }
                catch
                {
                    //Catches if sql email query doesnt work and adds custom email error
                    ModelState.AddModelError("LoginEmail", "Invalid Email");
                    ViewBag.errors = ModelState.Values;
                    return View("Index");
                }
                
            }
            //if form isnt valid
            ViewBag.errors = ModelState.Values;
            return View("Index");
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
