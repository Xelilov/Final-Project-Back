using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProjectShopping.Models;
using System.IO;
namespace FinalProjectShopping.Controllers
{
    [AuthorizationFilterUser]
    public class BusinessController : Controller
    {
        FinalProjectEntities db = new FinalProjectEntities();

        ProductViewModel new_product = new ProductViewModel();

        BusinessModel businesproduct = new BusinessModel();

        // GET: Business

        public ActionResult Index()
        {
            businesproduct._busines_user = LoginRegisterController.log_business;
            businesproduct._product = db.Products.Where(n => n.product_business_id == LoginRegisterController.log_business.business_id).ToList();
            businesproduct._product_img = db.ProductImages.ToList();
            businesproduct._size_count = db.ProductPivotSizes.ToList();
            return View(businesproduct);
        }


        public ActionResult Create()
        {
            new_product._category = db.Categories.ToList();
            new_product._innersubcategory = db.InnerSubcategories.ToList();
            new_product._subcategory = db.Subcategories.ToList();
            new_product._product_color = db.Colors.ToList();
            new_product._size = db.Sizes.ToList();
            return View(new_product);
        }

        [HttpPost]
        public ActionResult Create(Product product, List<HttpPostedFileBase> file, List<int> colorId, FormCollection form, List<int> product_size_count, List<int> product_count)
        {
            List<string> size_str_id =  form["checkBoxList_name"].Split(',').ToList();

            List<List<int>> size_id = new List<List<int>>();

            foreach (string item in size_str_id)
            {
                List<int> list = new List<int>();
                foreach (char c in item)
                { 
                    list.Add((int)Char.GetNumericValue(c));
                } 
                size_id.Add(list);
            }
            
           
            ProductPivotSize new_productsize = new ProductPivotSize();
            Random rnd = new Random();
            var randonnumber = rnd.Next(0, 100000);
            int product_business = LoginRegisterController.log_business.business_id;
            product.product_business_id = product_business;
            db.Products.Add(product);
            db.SaveChanges();
            var productLast = db.Products.OrderByDescending(a => a.product_id).FirstOrDefault();
            
            for (int i = 0; i < file.Count(); i++)
            {
                if (file[i] != null && colorId[i] != 0)
                {
                    var InputFileName = Path.GetFileName(file[i].FileName);
                    var ServerSavePath = Path.Combine(Server.MapPath("~/Upload/") + randonnumber + InputFileName);
                    //Save file to server folder  
                    file[i].SaveAs(ServerSavePath);
                    ProductImage productImage = new ProductImage();
                    productImage.product_img = "/Upload/" + randonnumber + InputFileName;
                    productImage.product_img_color_id = colorId[i];
                    productImage.product_img_product_id = productLast.product_id;
                    if (product_count[i] > 0)
                    {
                        productImage.product_img_count = Convert.ToInt32(product_count[i]);
                    }
                    else
                    {
                        productImage.product_img_count = null;
                    } 
                    db.ProductImages.Add(productImage);
                    db.SaveChanges();
                    for (int s = 0; s < size_id[i].Count; s++)
                    {
                        ProductPivotSize elem = new ProductPivotSize();
                        elem.product_pivot_img_id = productImage.product_img_id;
                        elem.product_pivot_size_id = size_id[i][s];
                        elem.product_pivot_count = 0;
                        db.ProductPivotSizes.Add(elem);
                        db.SaveChanges();
                    }
                }


            } 
            return RedirectToAction("Index");
        }

        //Delete
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            List<ProductImage> productimg = db.ProductImages.Where(s => s.product_img_product_id == id).ToList();
            List<ProductPivotSize> sizeproduct = db.ProductPivotSizes.ToList();
            foreach (var item in productimg)
            {
                foreach (var p_item in sizeproduct)
                {
                    if (p_item.product_pivot_img_id == item.product_img_id)
                    {
                        db.ProductPivotSizes.Remove(p_item);
                        db.SaveChanges();
                    }
                }                
                db.ProductImages.Remove(item);
                db.SaveChanges();
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            return View();
        }




    }
}



//        public ActionResult upload()
//        {
//            return View();
//        }

//        [HttpPost] 
//        public ActionResult upload(IEnumerable<HttpPostedFileBase> file)
//        {

//            foreach (HttpPostedFileBase item  in file)
//            {
//                //Checking file is available to save.  
//                if (item != null)
//                {
//                    var InputFileName = Path.GetFileName(item.FileName);
//                    var ServerSavePath = Path.Combine(Server.MapPath("~/Upload/") + InputFileName);
//                    //Save file to server folder  
//                    item.SaveAs(ServerSavePath);
//                    //assigning file uploaded status to ViewBag for showing message to user.
//                }

//            }
//            return View();
//        }
//    }
//}