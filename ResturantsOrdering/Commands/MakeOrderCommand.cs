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
            makeOrderViewModel = _makeOrderViewModel;
            ordersController = _ordersController;
        }

        public override void Execute(object parameter)
        {
            Order order = ordersController.CreateOrder(makeOrderViewModel);
            List<string> messages=new List<string> ();
            if (order == null)
            {
                messages.Add("You entered invalid ID, please check your item id and try again.\n");
                makeOrderViewModel.Messages += (messages[0]);
            }
            else
            {
                messages = ordersController.MakeOrder(order);
                makeOrderViewModel.Messages += (messages[0]);
                makeOrderViewModel.AllReceipt = (messages[1]);
            }

        }
    }
}
