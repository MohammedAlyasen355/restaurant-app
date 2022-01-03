using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
    public class Invoice
    {
        public int ID { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime InvoiceDate { get; set; }

        public double Bill { get; set; }

        public bool Description { get; set; }

        [ForeignKey("Order")]
        [DisplayName("Order")]
        public int OrderID { get; set; }

        public virtual Order Order { get; set; }

    }
}