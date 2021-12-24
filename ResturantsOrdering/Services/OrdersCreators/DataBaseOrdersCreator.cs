using ResturantsOrdering.DbContexts;
using ResturantsOrdering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantsOrdering.Services.OrdersCreators
{
    public class DataBaseOrdersCreator : IOrdersCreator
    {
        private readonly ApplicationDbContextFactory applicationDbContextFactory;

        public DataBaseOrdersCreator(ApplicationDbContextFactory applicationDbContextFactory)
        {
            this.applicationDbContextFactory = applicationDbContextFactory;
        }

        public async Task CreateOrder(Order order)
        {
            using (ApplicationDbContext _dbContext = applicationDbContextFactory.CreateDbContext())
            {
                _dbContext.Orders.Add(order);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
