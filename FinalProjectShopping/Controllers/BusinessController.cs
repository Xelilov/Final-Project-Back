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
                        elem.product_pivot_count = 5;
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
            List<UserBag> bagproduct = db.UserBags.Where(s => s.user_bag_product_id == id).ToList();

            if (bagproduct.Count>0)
            {
                foreach (var item in bagproduct)
                {
                    db.UserBags.Remove(item);
                    db.SaveChanges();
            }
            }
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
            ProductEditModel editPr = new ProductEditModel();
            editPr._editproduct = db.Products.Where(s => s.product_id == id).First();
            editPr._editProductImage = db.ProductImages.Where(s => s.product_img_product_id == id).ToList();
            editPr._category = db.Categories.ToList();
            editPr._subcategory = db.Subcategories.ToList();
            editPr._innersubcategory = db.InnerSubcategories.ToList();
            editPr._product_color = db.Colors.ToList();
            editPr._size = db.Sizes.ToList();
            editPr._sizeproduct = db.ProductPivotSizes.ToList();
            return View(editPr);
        }



        [HttpPost]
        public ActionResult Edit( int id, string product_name, string product_price, FormCollection form, List<int> product_count, List<int> product_size_count, List<int> product_pivot_id)
        {
            Product pr = db.Products.Find(id);
            pr.product_name = product_name;
            pr.product_price = product_price;
            db.SaveChanges();

            List<ProductImage> productimg = db.ProductImages.Where(s => s.product_img_product_id == id).ToList();
            if (product_count!=null)
            {
                
                for (int i = 0; i < productimg.Count; i++)
                {
                    productimg[i].product_img_count = product_count[i];
                    db.SaveChanges();
                }
            }
            else{

                for (int i = 0; i < product_pivot_id.Count; i++)
                {
                    ProductPivotSize pivot = db.ProductPivotSizes.Find(product_pivot_id[i]);
                    pivot.product_pivot_count = product_size_count[i];
                    db.SaveChanges();
                }
                

            }


            return RedirectToAction("Index");
        }

        public ActionResult categoty(int? id)
        {
            var a = Convert.ToInt32(id);
            db.Configuration.ProxyCreationEnabled = false;
            var subcat = db.Subcategories.Where(s => s.category_id == a).ToList();
            return Json(subcat, JsonRequestBehavior.AllowGet);
        }

        public ActionResult subcategoty(int? id)
        {
            var a = Convert.ToInt32(id);
            db.Configuration.ProxyCreationEnabled = false;
            var innersubcat = db.InnerSubcategories.Where(s => s.innersubcategory_subcategory_id == a).ToList();
            return Json(innersubcat, JsonRequestBehavior.AllowGet);
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