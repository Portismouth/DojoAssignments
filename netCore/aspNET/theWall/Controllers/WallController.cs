using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//
using theWall.Models;

namespace theWall.Controllers
{
    public class WallController : Controller
    {
        public void show()
        {
            string messageQuery = "SELECT messages.id, messages.message, messages.created_at, users_id, users.first_name, users.last_name FROM theWall.messages LEFT JOIN theWall.users ON messages.users_id = users.id";

            string commentQuery = "SELECT comments.comment, comments.created_at, comments.messages_id, users.first_name, users.last_name FROM theWall.comments LEFT JOIN users ON comments.users_id = users.id";

            List<Dictionary<string, object>> messages = _dbConnector.Query(messageQuery);
            List<Dictionary<string, object>> comments = _dbConnector.Query(commentQuery);

            ViewBag.Messages = messages;
            ViewBag.Comments = comments;
        }
        private readonly DbConnector _dbConnector;
 
        public WallController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        [HttpGet]
        [Route("Wall")]
        public IActionResult Index()
        {
            //Initiallize page with getting all messages from database
            show();

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
        [Route("message")]
        public IActionResult Content(Message newMessage)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    int? id = HttpContext.Session.GetInt32("UserId");
                    string query = $"INSERT INTO messages (message, created_at, updated_at, users_id) VALUES ('{newMessage.Content}', NOW(), NOW(), {id} )";
                    _dbConnector.Execute(query);
                    return RedirectToAction("Index");
                }
                catch
                {
                    ModelState.AddModelError("Content", "Please login to post");
                    ViewBag.errors = ModelState.Values;
                    show();
                    return View("Index");
                }
                
            }
            ViewBag.errors = ModelState.Values;
            show();
            return View("Index");
        }
        [HttpPost]
        [Route("message/{id}")]
        public IActionResult Comment(string comment, int id)
        {
            //I got lazy here. This only checks if the person is logged in or not to post a comment
            try
            {
                int? user_id = HttpContext.Session.GetInt32("UserId");
                string query = $"INSERT INTO comments (comment, created_at, updated_at, messages_id, users_id) VALUES ('{comment}', NOW(), NOW(), {id}, {user_id} )";
                _dbConnector.Execute(query);
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["error"] = "Please login before commenting";
                return RedirectToAction("Index");
            }
        }

    }
}
