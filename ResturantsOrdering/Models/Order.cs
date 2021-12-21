using ResturantsOrdering.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantsOrdering.Models
{
    public class Order
    {
        static int AllOrders = 0;
        
        public int Id { get; set; }
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
            Items = new List<Item>();
            Id = ++AllOrders;
        }
        public Order(MakeOrderViewModel order)
        {
            this.Id =++ AllOrders;
            this.CachierName = order.CachierName;
            this.CustomerName = order.CustomerName;
            this.CustomerPhoneNumber = order.CustomerPhoneNumber;
            this.OrderTime = DateTime.Now;
        }
        


    }
}
