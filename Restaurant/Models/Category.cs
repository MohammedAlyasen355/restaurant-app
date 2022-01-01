using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurant.Models
{
    public class Category
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products{ get; set; }

    }
}