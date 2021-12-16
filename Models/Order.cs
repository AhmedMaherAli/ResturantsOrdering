using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantsOrdering.Models
{
    public class Order
    {
        private static int NumberOfOrders=0;
        public int Id { get; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CachierName { get; set; }
        public int OrderTotalCost { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime DeliveryTime { get; set; }
        public List<Item> Items { get; set; }
        public TimeSpan timeToken;
        public Order()
        {
            Id = ++NumberOfOrders;
            Items = new List<Item>();
        }
        


    }
}
