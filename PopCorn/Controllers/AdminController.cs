using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PopCorn.Models.DAL;

namespace PopCorn.Controllers
{
    public class AdminController : Controller
    {
        private DataBaseContext _db = new DataBaseContext();

        // GET: Admin
        public ActionResult Index()
        {

            if (Session["Admin"] != null)
            {
               var model= _db.Messages.ToList();
                return View(model);

            }
            return RedirectToAction("login");

        }
    

        [HttpGet]
        public ActionResult login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult login(Users mode,  string username ,string password )
        {
            var user = _db.Users.Where(f => f.UserName == username && f.Password == password).FirstOrDefault();
            if ( user != null)
            {
                Session["Admin"] = "true";

              return  RedirectToAction("index");
            }
            return View();
        }

        public ActionResult logOff()
        {
            Session.Clear();
            return RedirectToAction("login");
        }






    }
}