using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResturantsOrdering.Models;
using ResturantsOrdering.ViewModels;

namespace ResturantsOrdering.Controllers
{
    public class OrdersController
    {
        private readonly MenuController menuController;
        private readonly List<Order> orders;
        public Order CurrentOrder;
        public OrdersController(MenuController _menuController)
        {
            menuController = _menuController;
            orders = new List<Order>();
        }
        public IEnumerable<Order> GetCustomerOrders(string CustomerName)
        {
            return orders.Where(O => O.CustomerName == CustomerName);
        }
        public Order CreateOrder(MakeOrderViewModel orderViewModel)
        {
            if (orderViewModel.OrderItems == null)
                return null;
            Order order = new Order(orderViewModel);
            List<Item> orderItems = new List<Item>();
            foreach (string line in orderViewModel.OrderItems.Split("\r\n"))
            {
                string[] operands = line.Split("=>");
                if (operands.Length == 2)
                {
                    int ItemID, Quantity;
                    bool canParseItemID = int.TryParse(operands[0], out ItemID);
                    bool canParseQuantity = int.TryParse(operands[1], out Quantity);
                    if (canParseItemID && canParseQuantity)
                    {
                        Item MenuItem = menuController.GetItemFromMenuById(ItemID);
                        if (MenuItem == null)
                            return null;
                        Item item = new Item(MenuItem);
                        item.Quantity = Quantity;
                        orderItems.Add(item);
                    }
                    else { return null; }
                }
                else { return null; }


            }
            order.Items = orderItems;
            CurrentOrder = order;
            return order;
        }
        public void CalculateOrderServiceTime(Order order)
        {
            order.DeliveryTime = DateTime.Now;
            order.timeToken = order.DeliveryTime.Subtract(order.OrderTime);
        }
        public List<string> MakeOrder(Order order)
        {
            StringBuilder message = new StringBuilder();
            StringBuilder orderReceipt = new StringBuilder();
            foreach (Item OrderItem in order.Items)
            {
                Item MenuItem = menuController.GetItemFromMenuById(OrderItem.Id);

                if (MenuItem.Quantity >= OrderItem.Quantity)
                {
                    order.OrderTotalCost += (MenuItem.Price * OrderItem.Quantity);
                    orderReceipt.Append($"{OrderItem.Quantity} {OrderItem.Name} = {OrderItem.Quantity * MenuItem.Price} \n");
                    MenuItem.Quantity -= OrderItem.Quantity;
                }
                else
                {
                    OrderItem.Quantity=0;
                    message.Append($"Sorry, there is only {MenuItem.Quantity} items left from {MenuItem.Name}.\n");
                }

            }
            foreach (Item OrderItem in order.Items)
            {
                Item MenuItem = menuController.GetItemFromMenuById(OrderItem.Id);
                MenuItem.Quantity += OrderItem.Quantity;
            }
            message.Append($"Order total cost: {order.OrderTotalCost}\n");
            message.Append(orderReceipt);
            orderReceipt.Append($"Order total cost: {order.OrderTotalCost}\n");
            orderReceipt.Append($"Order is created by {order.CachierName} \nOn Date and Time: {order.OrderTime}\n");
            List<string> messages = new List<string>();
            messages.Add(message.ToString());
            messages.Add(orderReceipt.ToString());
            CurrentOrder = order;
            return messages;
        }
        
        public void ConfirmOrder(Order order)
        {
            foreach (Item OrderItem in order.Items)
            {
                Item MenuItem = menuController.GetItemFromMenuById(OrderItem.Id);
                MenuItem.Quantity -= OrderItem.Quantity;
            }
            orders.Add(order);
        }
        public int GetNumberOfTotalOrders()
        {
            return orders.Count();
        }
    }
}
