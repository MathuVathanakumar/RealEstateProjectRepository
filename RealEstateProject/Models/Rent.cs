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
        public String Ptype { get; set; }
        public int Rooms { get; set; }

        [ForeignKey("owners")]
        [Display(Name = "OwnerNo")]
        [Column("OwnerNo_Ref")]
        public String RefOwnerNo { get; set; }
        public virtual Owner owners { get; set; }
        [ForeignKey("staffs")]
        [Display(Name = "StaffNo")]
        [Column("StaffNo_Ref")]
        public String RefStaffNo { get; set; }

        public virtual Staff staffs { get; set; }

        [ForeignKey("branches")]
        [Display(Name = "BranchNo")]
        [Column("BranchNo_Ref")]
        public String RefBranchNo { get; set; }
        public virtual Branch branches { get; set; }

        public int Rent1 { get; set; }
    }
}