using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bits_and_Bites.Models;
using System.Data.SqlClient;

namespace Bits_and_Bites.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BlogPost()
        {
            return View();
        }

        public ActionResult Static()
        {
            return View();
        }

        public ActionResult Archive()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Login";

            return View();
        }

        public ActionResult AddNewRecipe()
        {
            return View();
        }        

        [HttpPost]
        public ActionResult AddNewRecipe(Recipie newRecipe)
        {
            
            return View();
        }
    }
}