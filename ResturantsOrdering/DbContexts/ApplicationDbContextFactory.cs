using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantsOrdering.DbContexts
{
    public class ApplicationDbContextFactory
    {
        private readonly string connectionString;
        public ApplicationDbContextFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public ApplicationDbContext CreateDbContext()
        {
            DbContextOptions dbContextOptions = new DbContextOptionsBuilder().UseSqlServer(connectionString).Options;
            return new ApplicationDbContext(dbContextOptions);
        }
    }
}
