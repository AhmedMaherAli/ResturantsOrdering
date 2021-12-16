﻿using System;
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
            
            Order order = new Order();
            order.CustomerName = orderViewModel.CustomerName;
            order.CustomerPhoneNumber = orderViewModel.CustomerPhoneNumber;
            order.CachierName = orderViewModel.CachierName;
            order.OrderTime = DateTime.Now;
            List<Item> orderItems = new List<Item>();
            if (orderViewModel.OrderItems == null)
                return null;
            foreach ( string line in orderViewModel.OrderItems.Split("\r\n"))
            {
                string[] operands = line.Split("=>");
                int ItemID, Quantity;
                bool canParseItemID = int.TryParse(operands[0],out ItemID);
                bool canParseQuantity = int.TryParse(operands[1], out Quantity);
                if(canParseItemID && canParseQuantity && operands.Length == 2)
                {
                    Item MenuItem = menuController.GetItemFromMenuById(ItemID);
                    if (MenuItem == null)
                        return null;
                    Item item = new Item(MenuItem);
                    item.Quantity = Quantity;
                    orderItems.Add(item);
                }
                else
                {
                    return null;
                }
                
            }
            order.Items = orderItems;
            return order;
        }
        public void CalculateOrderServiceTime(Order order)
        {
            order.DeliveryTime = DateTime.Now;
            order.timeToken = order.DeliveryTime.Subtract(order.OrderTime);
        }
        public List<string> MakeOrder(Order order)
        {
            StringBuilder message=new StringBuilder();
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
                        message.Append($"Sorry, there is only {MenuItem.Quantity} items left from {MenuItem.Name}.\n");
                    }
                
            }
            message.Append($"Order total cost: {order.OrderTotalCost}\n");
            message.Append(orderReceipt);
            orderReceipt.Append($"Order total cost: {order.OrderTotalCost}\n");
            orderReceipt.Append($"Order is created by {order.CachierName} \nOn Date and Time: {order.OrderTime}\n");
            List<string> messages = new List<string>();
            messages.Add(message.ToString());
            messages.Add(orderReceipt.ToString());
            return messages;
        }
        public void ConfirmOrder(Order order)
        {
            orders.Add(order);
        }
        public int GetNumberOfTotalOrders()
        {
            return orders.Count();
        }
    }
}