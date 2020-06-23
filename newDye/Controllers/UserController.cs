using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using newDye.Models;

namespace newDye.Controllers
{
    public class UserController : Controller
    {
        eCOMMERCEDYEEntities db = new eCOMMERCEDYEEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            User userModel = new User();
            return View(userModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit(User userModel)
        {
            using (eCOMMERCEDYEEntities user=new eCOMMERCEDYEEntities())
            {
                if (user.User.Any(x => x.UserName == userModel.UserName))
                {
                    ViewBag.DuplicateMessage = "Username already exist";
                    return View("AddOrEdit", userModel);
                }
                user.User.Add(userModel);
                user.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccesMessage = "Registiration confirmed";
            return View("AddOrEdit", new User()); 
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Authorize(newDye.Models.User usermodel)
        {
            using(eCOMMERCEDYEEntities db=new eCOMMERCEDYEEntities())
            {
                var Userdetails = db.User.Where(x => x.UserName == usermodel.UserName && x.Password == usermodel.Password).FirstOrDefault();
                if (Userdetails==null)
                {
                    return View("Index", usermodel);

                }
                else
                {
                    Session["userID"] = Userdetails.UserID;
                    return RedirectToAction("Index", "Basket");
                }
            }
           
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "User");
        }
        public ActionResult ShowUsers()
        {
            var users = db.User.ToList();
            return View(users);
        }
     

    }
}