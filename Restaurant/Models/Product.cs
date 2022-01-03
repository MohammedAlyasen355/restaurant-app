using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Product
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }

        [ForeignKey("Category")]
        [DisplayName("Category")]
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }

        [ForeignKey("Order")]
        [DisplayName("Order")]
        public int OrderID { get; set; }

        public virtual Order Order { get; set; }

    }
}