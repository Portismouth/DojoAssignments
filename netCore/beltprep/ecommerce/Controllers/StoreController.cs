using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//
using Microsoft.EntityFrameworkCore;
using ecommerce.Models;
using System.Linq;
//
using Microsoft.AspNetCore.Identity;

namespace ecommerce.Controllers
{
    public class StoreController : Controller
    {
        private Context _context;
 
        public StoreController(Context context)
        {
            _context = context;
        }
        //Current datetime
        public DateTime now()
        {
            DateTime now = DateTime.Now;
            return now;
        }
        public bool CheckLoggedIn()
        {
            int? id = HttpContext.Session.GetInt32("LOGGED_IN_USER");
            User LoggedIn = _context.Users.SingleOrDefault(user => user.userid == id);
            ViewBag.User = LoggedIn;
            if(ViewBag.User != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void GetCustomers()
        {
            List<Customer> AllCustomers = _context.Customers.ToList();
            ViewBag.customers = AllCustomers;
        }
        // GET: /Home/
        [HttpGet]
        [Route("/dashboard")]
        public IActionResult Index()
        {
            if(!CheckLoggedIn())
            {
                return RedirectToAction("Index", "Home");
            }
            List<Customer> homeCustomers = _context.Customers.OrderByDescending(c => c.createdat).Take(3).ToList();
            List<Product> homeProducts = _context.Product.OrderByDescending(c => c.productid).Take(3).ToList();
            List<Order> homeOrders = _context.Orders.OrderByDescending(c => c.createdat).Take(3).Include(c => c.customer).ToList();

            StoreWrapper model = new StoreWrapper(homeCustomers, homeOrders, homeProducts);
            return View(model);
        }
        // Orders get route
        [HttpGet]
        [Route("/orders")]
        public IActionResult Orders()
        {
            CheckLoggedIn();
            List<Customer> AllCustomers = _context.Customers.ToList();
            List<Order> AllOrders = _context.Orders.ToList();
            List<Product> AllProducts = _context.Product.ToList();

            StoreWrapper model = new StoreWrapper(AllCustomers, AllOrders, AllProducts);
            return View(model);
        }
        // Create new order route
        [HttpPost]
        [Route("/orders")]
        public IActionResult NewOrder(int customer, int product, int quantity)
        {
            CheckLoggedIn();
            Customer CustomerOrder = _context.Customers.SingleOrDefault(c => c.customerid == customer);
            Product ProductOrder = _context.Product.SingleOrDefault(c => c.productid == product);

            Order NewOrder = new Order(){
                quantity = quantity,
                createdat = now(),
                product = ProductOrder,
                customer = CustomerOrder
            };
            ProductOrder.quantity -= quantity;
            _context.Orders.Add(NewOrder);
            _context.SaveChanges();

            return RedirectToAction("Orders");
        }
        //Customers Route
        [HttpGet]
        [Route("/customers")]
        public IActionResult Customers()
        {
            CheckLoggedIn();
            List<Customer> AllCustomers = _context.Customers.ToList();
            ViewBag.customers = AllCustomers;
            return View();
        }
        //Create Customers Route
        [HttpPost]
        [Route("/customers")]
        public IActionResult NewCustomer(Customer model)
        {
            if(ModelState.IsValid)
            {
                Customer newCustomer = new Customer()
                {
                    name = model.name,
                    createdat = now()
                };
                _context.Customers.Add(newCustomer);
                _context.SaveChanges();
                return RedirectToAction("Customers");
            }
            CheckLoggedIn();
            GetCustomers();
            ViewBag.errors = ModelState.Values;
            return View("Customers");
        }
        //Delete Customer route
        [HttpGet]
        [Route("/customers/delete/{customerid}")]
        public IActionResult DeleteCustomer(int customerid)
        {
            Customer toDelete = _context.Customers.SingleOrDefault(c => c.customerid == customerid);
            _context.Customers.Remove(toDelete);
            _context.SaveChanges();
            return RedirectToAction("Customers");
        }

        //Products
        [HttpGet]
        [Route("products")]
        public IActionResult Products(string search)
        {
            CheckLoggedIn();
            if(search != null)
            {
                List<Product> products = _context.Product.Where(p => p.name.ToLower().Contains(search.ToLower())).ToList();
                Search searchfilter = new Search(){filter = search};
                ProductWrapper filtermodel = new ProductWrapper(products, searchfilter);
                return View(filtermodel);
            }
            List<Product> productsModel = _context.Product.ToList();
            Search searchModel = new Search(){filter = search};
            ProductWrapper model = new ProductWrapper(productsModel, searchModel);

            return View(model);
        }
        //Add Products
        [HttpPost]
        [Route("products")]
        public IActionResult AddProduct(string name, string url, string desc, int quantity)
        {
            CheckLoggedIn();
            Product NewProduct = new Product(){
                name = name,
                image = url,
                description = desc,
                quantity = quantity
            };
            _context.Product.Add(NewProduct);
            _context.SaveChanges();
            return RedirectToAction("Products");
        }
        [HttpPost]
        [Route("search")]
        public IActionResult Search(string filter)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Products", new {search = filter});
            }
            return RedirectToAction("Products");
        }
    }
}
