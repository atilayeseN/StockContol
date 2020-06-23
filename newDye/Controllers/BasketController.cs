using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using newDye.Models;


namespace newDye.Controllers
{
    public class BasketController : Controller
    {
        eCOMMERCEDYEEntities db = new eCOMMERCEDYEEntities();
        public ActionResult Index()
        {
            var prd = db.Products.ToList();

            return View(prd);

        }
        public ActionResult AddtoCart(int productid)
        {
            if (Session["card"] == null)
            {
                List<Item> cart = new List<Item>();
                var product = db.Products.Find(productid);
                cart.Add(new Item()
                {
                    Product = product,
                    Litre = 1
                });
                Session["cart"] = cart;

            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var product = db.Products.Find(productid);
                cart.Add(new Item()
                {
                    Product = product,
                    Litre = 1
                });
                Session["cart"] = cart;
            }
            return RedirectToAction("Pay");
        }
        
        public ActionResult Pay()

        {
            return View();
        }
        [HttpPost]

       
        public ActionResult Order()
        {
            Payements payement = new Payements();
            foreach (var ıtem in (List<Item>)Session["cart"])
            {
                var item = Convert.ToInt32(ıtem.Product.ProductID);
                
                db.SaveChanges();
            }
            return View("Index");
        }




    }
   }
