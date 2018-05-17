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
            cathtml._product = db.Products.ToList();
            return View(cathtml);
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
            ViewBag.innerid = id;

            return View(cathtml);
        }
        public ActionResult Product(int? id)
        {
            ViewBag.log = LoginRegisterController.log_user;
            ViewBag.img = db.ProductImages.Where(d => d.product_img_product_id == id).ToList();
            cathtml._oneproduct = db.Products.Where(p => p.product_id == id).FirstOrDefault();
            cathtml._product = db.Products.ToList();
            cathtml._color = db.Colors.ToList();
            cathtml._size = db.Sizes.ToList();
            return View(cathtml);
        }
        public ActionResult Imgsize(int? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var size = db.ProductPivotSizes.Where(s => s.product_pivot_img_id == id).Select(t => t.Size).ToList();
            return Json(size, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getCount(int? id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var count = db.ProductImages.Where(s => s.product_img_id == id).First().product_img_count;
            return Content(count.ToString());
        }
        public ActionResult getSizeCount(int img_id, int size_id)
        {
            var x = db.ProductPivotSizes.Where(p => p.product_pivot_img_id == img_id && p.product_pivot_size_id == size_id).First().product_pivot_count;
            return Content(x.ToString());
        }

        public ActionResult Minprice(string minprice, string innerid, string maxprice)
        {
            int a = Convert.ToInt32(innerid);
            decimal b = Convert.ToDecimal(minprice);
            decimal d = Convert.ToDecimal(maxprice);
            db.Configuration.ProxyCreationEnabled = false;
            var product = db.Products.Where(s => s.product_innersubcategory_id == a).ToList();
            List<test> listProduct1 = new List<test>();

            List<Product> listProduct = new List<Product>();
            List<ProductImage> productimag = new List<ProductImage>();
            foreach (var item in product)
            {
                decimal c = Convert.ToDecimal(item.product_price);
                if (c >= b && c <= d)
                {
                    listProduct.Add(db.Products.Where(s => s.product_id == item.product_id).First());
                    productimag.Add(db.ProductImages.Where(m => m.product_img_product_id == item.product_id).First());
                }
            }
            for (int i = 0; i < listProduct.Count; i++)
            {
                test ssss = new test();
                ssss.product_name = listProduct[i].product_name;
                ssss.product_price = listProduct[i].product_price;
                ssss.product_id = listProduct[i].product_id;
                ssss.Image = productimag[i].product_img.ToString();
                listProduct1.Add(ssss);
            }
            
            return Json(listProduct1, JsonRequestBehavior.AllowGet);
        }
    }
}