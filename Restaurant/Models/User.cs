using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
    public class User
    {

        public int ID { get; set; }

        // later on
        // public int GroupID{ get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string UserName { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        public int Active { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }

        public string Gender { get; set; }

        public string Deleted { get; set; }

        public int ApprovedAdminID { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime ApprovedDate { get; set; }


        [ForeignKey("Order")]
        [DisplayName("Order")]
        public int OrderID { get; set; }

        public virtual Order Order { get; set; }

    }
}