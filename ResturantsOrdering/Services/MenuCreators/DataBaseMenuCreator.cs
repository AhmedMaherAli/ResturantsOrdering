using ResturantsOrdering.DbContexts;
using ResturantsOrdering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantsOrdering.Services.MenuCreators
{
    public class DataBaseMenuCreator: IMenuCreator
    {
        private readonly ApplicationDbContextFactory applicationDbContextFactory;

        public DataBaseMenuCreator(ApplicationDbContextFactory applicationDbContextFactory)
        {
            this.applicationDbContextFactory = applicationDbContextFactory;
        }

        public async Task CreateMenu(Menu menu)
        {
            using(ApplicationDbContext _dbContext= applicationDbContextFactory.CreateDbContext())
            {
                _dbContext.Menu.Add(menu);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
