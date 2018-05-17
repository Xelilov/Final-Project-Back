using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProjectShopping.Models;

namespace FinalProjectShopping.Controllers
{
    
    public class UserBagController : Controller
    {
        FinalProjectEntities db = new FinalProjectEntities();
        UserBagModel modeluserbag = new UserBagModel();
        // GET: UserBag
        public ActionResult Index()
        {
            if (LoginRegisterController.log_user!=null)
            {
                modeluserbag._user = LoginRegisterController.log_user;
                modeluserbag._user_bag = db.UserBags.Where(s => s.user_bag_user_id == LoginRegisterController.log_user.user_id).ToList();
                return View(modeluserbag);
            }
            else
            {
                modeluserbag._user = LoginRegisterController.log_user;
                return View(modeluserbag);
            }
        }

        [HttpPost]
        public ActionResult Create(int product_id, int product_img_id, string product_pivot_id, int product_count)
        {
            UserBag new_bag = new UserBag();
            new_bag.user_bag_user_id = LoginRegisterController.log_user.user_id;
            new_bag.user_bag_product_id = product_id;
            new_bag.user_bag_product_img_id = product_img_id;
            if (product_pivot_id == "")
            {
                new_bag.user_bag_product_pivot_id = null;
            }
            else
            {
                int y = Convert.ToInt32(product_pivot_id);
                var x = db.ProductPivotSizes.Where(s => s.product_pivot_img_id == product_img_id && s.product_pivot_size_id == y).First().product_pivot_id;
                new_bag.user_bag_product_pivot_id = x;
            }
            
            new_bag.user_bag_product_count = product_count;
            db.UserBags.Add(new_bag);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            UserBag bag = db.UserBags.Find(id);
            db.UserBags.Remove(bag);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}