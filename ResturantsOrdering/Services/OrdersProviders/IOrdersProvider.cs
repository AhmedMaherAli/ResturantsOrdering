using ResturantsOrdering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantsOrdering.Services.OrdersProviders
{
    public interface IOrdersProvider
    {
        Task<IEnumerable<Order>> GetAllOrders();
    }
}
