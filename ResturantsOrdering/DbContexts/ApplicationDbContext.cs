using Microsoft.EntityFrameworkCore;
using ResturantsOrdering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantsOrdering
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
                
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Item> Item { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(@"Data Source=DESKTOP-H0BVTLL\AHMEDMAHER;Initial Catalog = ResturantsOrdering; Integrated Security = True");

    }
}
