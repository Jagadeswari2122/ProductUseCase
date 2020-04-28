using System;
using System.Collections.Generic;

namespace ProductManagementDBEntity.Models
{
    public partial class UserDetails
    {
        public UserDetails()
        {
            Products = new HashSet<Products>();
        }

        public string Userid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Emailid { get; set; }
        public string Contactnumber { get; set; }
        public DateTime? Registereddatetime { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
