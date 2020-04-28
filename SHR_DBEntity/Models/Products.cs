using System;
using System.Collections.Generic;

namespace ProductManagementDBEntity.Models
{
    public partial class Products
    {
        public string Productid { get; set; }
        public string Productname { get; set; }
        public string Description { get; set; }
        public int Noofitems { get; set; }
        public int Price { get; set; }
        public DateTime? Createddatetime { get; set; }
        public string Image { get; set; }
        public string Userid { get; set; }

        public virtual UserDetails User { get; set; }
    }
}
