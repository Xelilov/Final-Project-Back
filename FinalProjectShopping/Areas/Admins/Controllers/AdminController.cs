using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProjectShopping.Areas.Admins.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admins/Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}