using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using newDye.Models;

namespace newDye.Controllers
{
    public class CategoryController : Controller
    {
        eCOMMERCEDYEEntities ct = new eCOMMERCEDYEEntities();
        public ActionResult Index()
        {
            var values = ct.Category.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewCategory()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult NewCategory(Category p1)
        {
            if (!ModelState.IsValid) {
                return View("NewCategory");
            }
            ct.Category.Add(p1);
            ct.SaveChanges();
            return View();
        }
        public ActionResult Delete(int id)
        {
            var category = ct.Category.Find(id);
            ct.Category.Remove(category);
            ct.SaveChanges();
            return RedirectToAction("Index");
        }
        
        
        

    }
}