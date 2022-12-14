//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoApp2.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Products
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Products()
        {
            this.Orders = new HashSet<Orders>();
        }
    
        public int Product_id { get; set; }
        public string Product_article { get; set; }
        public string Product_name { get; set; }
        public string Product_dimension { get; set; }
        public float Product_cost { get; set; }
        public Nullable<float> Product_maxDiscount { get; set; }
        public int Product_manufacturer { get; set; }
        public int Product_provider { get; set; }
        public int Product_type { get; set; }
        public Nullable<float> Product_discount { get; set; }
        public int Product_stock { get; set; }
        public string Product_description { get; set; }
        public byte[] Product_image { get; set; }
    
        public virtual Manufacturers Manufacturers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ProductTypes ProductTypes { get; set; }
        public virtual Providers Providers { get; set; }
    }
}
