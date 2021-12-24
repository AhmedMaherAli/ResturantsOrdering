using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantsOrdering.DbContexts
{
    public class ResturantsOrderingDtDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            DbContextOptions dbContextOptions= new DbContextOptionsBuilder().UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ResturatsOrdering;Trusted_Connection=True;MultipleActiveResultSets=True").Options;
            return new ApplicationDbContext( dbContextOptions);
        }
    }
}
