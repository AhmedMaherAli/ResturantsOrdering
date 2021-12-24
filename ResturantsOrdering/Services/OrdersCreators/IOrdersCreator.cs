using ResturantsOrdering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantsOrdering.Services.OrdersCreators
{
    public interface IOrdersCreator
    {
        Task CreateOrder(Order order);
    }
}
