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

        [ForeignKey("Invoice")]
        public int InvoiceID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }

        public virtual Invoice Invoice { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }

    }
}