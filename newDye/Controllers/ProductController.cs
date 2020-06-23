using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using newDye.Models;

namespace newDye.Controllers
{
    public class ProductController : Controller
    {
        eCOMMERCEDYEEntities db = new eCOMMERCEDYEEntities();
        public ActionResult Index()
        {
            var values = db.Products.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> values = (from i in db.Category.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CategoryName,
                                               Value = i.CategoryID.ToString()
                                           }).ToList();
            ViewBag.vl = values;
            return View();
                                           
        }
        [HttpPost]
        public ActionResult AddProduct(Products p1)
        {
            var ctg = db.Category.Where(m => m.CategoryID == p1.Category1.CategoryID).FirstOrDefault();
            p1.Category1 = ctg;
            db.Products.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index","Product");
        }
        public ActionResult Delete(int id)
        {
            var prd = db.Products.Find(id);
            db.Products.Remove(prd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}