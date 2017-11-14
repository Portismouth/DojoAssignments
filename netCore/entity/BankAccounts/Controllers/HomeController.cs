using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//
using Microsoft.EntityFrameworkCore;
using BankAccounts.Models;
using System.Linq;

namespace BankAccounts.Controllers
{
    public class HomeController : Controller
    {
        private Context _context;
 
        public HomeController(Context context)
        {
            _context = context;
        }
        // --------------------- Page Loading: Home / Account ---------------- //
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            try
            {
                int? id = HttpContext.Session.GetInt32("LOGGED_IN_USER");
                User LoggedIn = _context.Users.SingleOrDefault(user => user.id == id);
                ViewBag.User = LoggedIn;
                return View();
            }
            catch
            {
                return View();
            }
            
        }

        [HttpGet]
        [Route("account/{id}")]
        public IActionResult Account(int id)
        {
            int? UserID = HttpContext.Session.GetInt32("LOGGED_IN_USER");
            if (UserID == null)
            {
                return RedirectToAction("Index");
            }
            else if (UserID != id)
            {
                return RedirectToAction("Account", new {id = UserID});
            }
            else
            {
                User LoggedIn = _context.Users.SingleOrDefault(user => user.id == id);
                List<Account> allChanges = _context.AccountChanges.Where(c => c.Users_id == UserID).ToList();
                            
                ViewBag.User = LoggedIn;
                ViewBag.History = allChanges;
                return View();
            }
        }


        [HttpPost]
        [Route("change")]
        public IActionResult Change(AccountChange model)
        {
            int? UserID = HttpContext.Session.GetInt32("LOGGED_IN_USER");
            User LoggedIn = _context.Users.SingleOrDefault(user => user.id == UserID);
            DateTime now = DateTime.Now;
            if(ModelState.IsValid)
            {
                if(model.change == "Deposit")
                {
                    //Add item to balance change table
                    Account BalanceChange = new Account
                    {
                        change = model.amount,
                        Users_id = (int)UserID,
                        date = now
                    };
                    _context.Add(BalanceChange);
                    _context.SaveChanges();

                    //Update balance which is under user
                    LoggedIn.balance += model.amount;
                    _context.SaveChanges();

                    return RedirectToAction("Account", new {id = UserID});
                }

                if(model.change == "Withdraw")
                {
                    //Update balance which is under user
                    LoggedIn.balance -= model.amount;
                    if(LoggedIn.balance < 0)
                    {
                        TempData["error"] = "You cannot withdraw past 0";
                        return RedirectToAction("Account", new {id = UserID});
                    }
                    _context.SaveChanges();
                    Account BalanceChange = new Account{
                        change = model.amount - (model.amount * 2),
                        Users_id = (int)UserID,
                        date = now 
                    };
                    _context.Add(BalanceChange);
                        _context.SaveChanges();
                    return RedirectToAction("Account", new {id = UserID});
                }
            }
            ViewBag.errors = ModelState.Values;
            return RedirectToAction("Account", new {id = UserID});
        }


        // ---------------- REGISTER LOGIN LOGOUT ------------------------------------/
        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserRegister model)
        {
            if(ModelState.IsValid)
            {
                //Handle success, if any of it failes it hits the catch statement and returns you to the page with email already taken error
                try 
                {
                    User Newuser = new User
                    {
                        firstname = model.firstname,
                        lastname = model.lastname,
                        email = model.email,
                        password = model.password
                    };

                    _context.Add(Newuser);
                    _context.SaveChanges();
                    User RetrievedUser = _context.Users.SingleOrDefault(user => user.email == model.email);

                    HttpContext.Session.SetInt32("LOGGED_IN_USER", RetrievedUser.id);
                    int? user_id = HttpContext.Session.GetInt32("LOGGED_IN_USER");
                    return RedirectToAction("Account", new { id = user_id });
                }
                catch
                {
                    //this should only catch if email is already taken. Other fields validated
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
        public IActionResult login(UserLogin model)
        {
            if(ModelState.IsValid)
            {
                //Handle success, if any of it failes it hits the catch statement and returns you to the page with email already taken error
                try 
                {
                    User RetrievedUser = _context.Users.SingleOrDefault(user => user.email == model.LoginEmail);
                    if(model.LoginPassword == RetrievedUser.password)
                    {
                        HttpContext.Session.SetInt32("LOGGED_IN_USER", RetrievedUser.id);
                        int? user_id = HttpContext.Session.GetInt32("LOGGED_IN_USER");
                        return RedirectToAction("Account", new { id = user_id });
                    }
                   else
                   {
                        ModelState.AddModelError("LoginPassword", "Password does not match our records");
                        ViewBag.errors = ModelState.Values;
                        return View("Index");
                   } 
                }
                catch
                {
                    //this should only catch if email is already taken. Other fields validated
                    ModelState.AddModelError("LoginEmail", "Email not valid");
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
