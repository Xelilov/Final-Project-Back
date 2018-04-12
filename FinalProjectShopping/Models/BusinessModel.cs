using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProjectShopping.Models
{
    public class BusinessModel
    {
        public BusinessAccount _busines_user { get; set; }
        public List<Product> _product { get; set; }
        public List<ProductImage> _product_img { get; set; }
        public List<ProductPivotSize> _size_count { get; set; }
    }
}