using ResturantsOrdering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantsOrdering.ViewModels
{
    public class OrderViewModel:ViewModelBase
    {
        private readonly Order _order;

        public string Id => _order.Id.ToString();
        public string CustomerName => _order.CustomerName;
        public string CustomerPhoneNumber => _order.CustomerPhoneNumber;
        public string CachierName => _order.CachierName;
        public DateTime OrderTime => _order.OrderTime;
        public List<Item> Items => _order.Items;
        public OrderViewModel(Order order)
        {
            _order = order;
        }
    }
}
