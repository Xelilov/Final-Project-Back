using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProjectShopping.Models;

namespace FinalProjectShopping.Controllers
{
    public class HomeController : Controller
    {
        FinalProjectEntities db = new FinalProjectEntities();
        CategoryHtmlVM cathtml = new CategoryHtmlVM();
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Category(int id)
        {
            cathtml._category = db.Categories.Where(c => c.category_id == id).FirstOrDefault();                      
            cathtml._subcategory = db.Subcategories.Where(s=>s.category_id==id).ToList();
            cathtml._product = db.Products.Where(p => p.product_category_id == id).ToList();
            return View(cathtml);
        }

        public ActionResult Subcategory(int? id)
        {
            cathtml._innersub = db.InnerSubcategories.Where(n => n.innersubcategory_subcategory_id == id).ToList();
            cathtml._product = db.Products.Where(p => p.product_subcategory_id == id).ToList();
            return View(cathtml);
        }

        public ActionResult InnerSub(int? id)
        {
            cathtml._product = db.Products.Where(p => p.product_innersubcategory_id == id).ToList();
            return View(cathtml);
        }

        public ActionResult Product(int? id)
        {
            ViewBag.img = db.ProductImages.Where(d => d.product_img_product_id == id).ToList();
            cathtml._oneproduct = db.Products.Where(p => p.product_id == id).FirstOrDefault();
            return View(cathtml);
        }
    }
}