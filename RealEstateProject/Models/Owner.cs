using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateProject.Models
{
    [Table("Owner_tbl")]
    public class Owner
    {
        [Key]
        public String OwnerNo { get; set; }
        [Display(Name = "Firstname")]
        public String Fname { get; set; }
        [Display(Name = "Lastname")]
        public String Lname { get; set; }
        public String Address { get; set; }

        [Display(Name = "TelephoneNo")]
        public String TelNo { get; set; }

        public virtual List<Rent> rents { get; set; }
    }
}