//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProjectShopping.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductPivotSize
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductPivotSize()
        {
            this.UserBags = new HashSet<UserBag>();
        }
    
        public int product_pivot_id { get; set; }
        public int product_pivot_img_id { get; set; }
        public Nullable<int> product_pivot_size_id { get; set; }
        public int product_pivot_count { get; set; }
    
        public virtual ProductImage ProductImage { get; set; }
        public virtual Size Size { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserBag> UserBags { get; set; }
    }
}
