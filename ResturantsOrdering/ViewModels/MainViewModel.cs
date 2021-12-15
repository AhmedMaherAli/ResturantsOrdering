using ResturantsOrdering.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantsOrdering.ViewModels
{
    public class MainViewModel :ViewModelBase
    {
        public ViewModelBase CurrentViewModel{get;}
        public MainViewModel(OrdersController ordersController)
        {
            CurrentViewModel = new MakeOrderViewModel(ordersController);
        }
    }
}
