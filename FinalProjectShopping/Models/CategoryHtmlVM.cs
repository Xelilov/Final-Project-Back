using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectShopping.Models
{
    public class CategoryHtmlVM
    {
        public Category _category { get; set; }
        public List<Subcategory> _subcategory { get; set; }
        public List<InnerSubcategory> _innersub { get; set; }
        public List<Product> _product { get; set; }
        public Product _oneproduct { get; set; }
    }
}