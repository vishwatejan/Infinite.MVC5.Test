using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace Infinite.MVC5.Test.Models
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext() : base("FruitCon")
        {

        }
        public DbSet<Fruits> Fruit { get; set; }
        public DbSet<PackSize> Packs { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}