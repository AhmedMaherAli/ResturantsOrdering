using Microsoft.EntityFrameworkCore;
using ResturantsOrdering.DbContexts;
using ResturantsOrdering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantsOrdering.Services.OrdersProviders
{
    public class DataBaseOrdersProvider : IOrdersProvider
    {
        private readonly ApplicationDbContextFactory applicationDbContexFactory;

        public DataBaseOrdersProvider(ApplicationDbContextFactory applicationDbContexFactory)
        {
            this.applicationDbContexFactory = applicationDbContexFactory;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            using (ApplicationDbContext _dbContext = applicationDbContexFactory.CreateDbContext())
            {
                return await _dbContext.Orders.ToListAsync();
            }
        }
    }
}
