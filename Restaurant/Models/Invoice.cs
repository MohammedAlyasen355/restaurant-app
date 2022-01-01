using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Invoice
    {
        public int ID { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime InvoiceDate { get; set; }

        public double Bill { get; set; }

        public bool Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}