using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateProject.Models
{
    [Table("Staff_tbl")]
    public class Staff
    {

        [Key]
        public String StaffNo { get; set; }
        public String Fname { get; set; }
        public String Lname { get; set; }
        public String Position { get; set; }
        [Column(TypeName ="Date")]
        public DateTime DOB { get; set; }
        public int Salary { get; set; }

        [ForeignKey("branches")]
        [Display(Name = "BranchNo")]
        [Column("BranchNo_Ref")]
        public String Branch_BranchNo { get; set; }

        public virtual Branch branches { get; set; }



    }
}