using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RealEstateProject.Models
{
    [Table("Rent_tbl")]
    public class Rent
    {
        [Key]
        public String PropertyNo { get; set; }
        public String Street { get; set; }
        public String City { get; set; }
        [Display(Name = "Property Type")]
        public String Ptype { get; set; }
        [Display(Name = "No of Rooms")]
        public int Rooms { get; set; }

        [ForeignKey("owners")]
        [Column("OwnerNo_Ref")]
        [Display(Name = "OwnerNo")]
        public String RefOwnerNo { get; set; }
        public virtual Owner owners { get; set; }
        [ForeignKey("staffs")]
        [Column("StaffNo_Ref")]
        [Display(Name = "StaffNo")]
        public String RefStaffNo { get; set; }

        public virtual Staff staffs { get; set; }

        [ForeignKey("branches")]
        [Column("BranchNo_Ref")]
        [Display(Name = "BranchNo")]
        public String RefBranchNo { get; set; }
        public virtual Branch branches { get; set; }

        [Display(Name = "Rent")]
        public int Rent1 { get; set; }
    }
}