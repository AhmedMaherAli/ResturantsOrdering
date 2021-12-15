using ResturantsOrdering.Controllers;
using ResturantsOrdering.Models;
using ResturantsOrdering.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantsOrdering.Commands
{
    public class MakeOrderCommand : CommandBase
    {
        private readonly OrdersController ordersController;
        private readonly MakeOrderViewModel makeOrderViewModel;

        public MakeOrderCommand(MakeOrderViewModel _makeOrderViewModel, OrdersController _ordersController)
        {
            ordersController = _ordersController;
            makeOrderViewModel = _makeOrderViewModel;
        }

        public override void Execute(object parameter)
        {
            Order order = ordersController.CreateOrder(makeOrderViewModel);
            string message;
            if (order == null)
            {
                message = "You entered invalid ID, please check your item id and try again.\n";
            }
            else
            {
                message = ordersController.MakeOrder(order);
                makeOrderViewModel.Messages += (message);
                ordersController.ConfirmOrder(order);
            }

        }
    }
}
