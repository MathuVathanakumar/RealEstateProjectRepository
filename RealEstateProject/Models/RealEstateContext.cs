using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RealEstateProject.Models
{
    public class RealEstateContext:DbContext
    {
        public DbSet<Owner> owners { get; set; }

        public DbSet<Rent> rents { get; set; }

        public DbSet<Staff> staffs { get; set; }
        public DbSet<Branch> branches { get; set; }
    }
}