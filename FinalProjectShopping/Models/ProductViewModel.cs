﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectShopping.Models
{
    public class ProductViewModel
    {        
        public List<Color> _product_color { get; set; }
        public List<Category> _category { get; set; }
        public List<Subcategory> _subcategory { get; set; }
        public List<InnerSubcategory> _innersubcategory { get; set; }
        public List<Size> _size { get; set; }
    }
}