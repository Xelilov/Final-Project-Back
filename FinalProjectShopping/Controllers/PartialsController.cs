using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProjectShopping.Models;

namespace FinalProjectShopping.Controllers
{
    public class PartialsController : Controller
    {
        FinalProjectEntities db = new FinalProjectEntities();


        public PartialViewResult Menu()
        {
            var _menu_view = new MenuViewModel();
            _menu_view._category = db.Categories.ToList();
            _menu_view._subcategory = db.Subcategories.ToList();
            return PartialView(_menu_view);
        }

    }
}