using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Order
    {
        public int ID { get; set; }

        public int Quantity { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Invoice> Invocies { get; set; }

    }
}