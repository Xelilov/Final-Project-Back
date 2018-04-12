using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProjectShopping.Models;

namespace FinalProjectShopping.Controllers
{
    public class LoginRegisterController : Controller
    {
        FinalProjectEntities db = new FinalProjectEntities();

        // GET: LoginRegister
        public ActionResult Index()
        {           
            return View();
        }

        public ActionResult User_register(string user_name, string user_email, string user_password, string user_confirm_pass)
        { 
            UserAccount new_user = new UserAccount();
            if (user_name != "" && user_email != "" && user_password != "" && user_confirm_pass !="")
            {
                if (user_password == user_confirm_pass)
                {
                    new_user.user_name = user_name;
                    new_user.user_email = user_email;
                    new_user.user_password = user_password;
                    db.UserAccounts.Add(new_user);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        public ActionResult Business_register(string business_name, string business_email, string business_password, string business_confirm_pass, string business_phone, string business_location)
        {
            if (business_name !="" && business_email !="" && business_password != "" && business_confirm_pass != "" && business_phone != "" && business_location != "")
            {
                if (business_password== business_confirm_pass)
                {
                    BusinessAccount new_business = new BusinessAccount();
                    new_business.business_name = business_name;
                    new_business.business_email = business_email;
                    new_business.business_password = business_password;
                    new_business.business_phone = business_phone;
                    new_business.business_location = business_location;
                    db.BusinessAccounts.Add(new_business);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult LogIn()
        {
            return RedirectToAction("Index", "Home");
        }

        public static UserAccount log_user;
        public static BusinessAccount log_business;
        [HttpPost]
        public ActionResult LogIn(string email, string password)
        {            
            log_user = db.UserAccounts.Where(u => u.user_email == email && u.user_password==password).FirstOrDefault();
            log_business = db.BusinessAccounts.Where(b => b.business_email == email && b.business_password==password).FirstOrDefault();
            
            if (log_user != null)
            {
                Session["user_email"] = log_user.user_email;
                return RedirectToAction("Index", "Home");
            }
            if (log_business !=null )
            {
                Session["business_email"] = log_business.business_email;
                return RedirectToAction("Index", "Business");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        public ActionResult LogOut()
        {
            Session["business_email"] = null;
            return RedirectToAction("Index", "LoginRegister");
        }




    }
}