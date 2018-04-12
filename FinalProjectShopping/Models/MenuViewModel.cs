using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectShopping.Models
{
    public class MenuViewModel
    {
        public List<Category> _category { get; set; }
        public List<Subcategory> _subcategory { get; set; }
    }
}