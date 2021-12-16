using ResturantsOrdering.Commands;
using ResturantsOrdering.Controllers;
using ResturantsOrdering.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ResturantsOrdering.ViewModels
{

    public class MakeOrderViewModel : ViewModelBase
    {

        private string customerName;
        public string CustomerName
        {
            get
            {
                return customerName;
            }
            set
            {
                customerName = value;
                OnPropertyChanged(nameof(CustomerName));
            }
        }
        
        private string cutomerPhoneNumber;
        
        public string CustomerPhoneNumber
        {
            get
            {
                return cutomerPhoneNumber;
            }
            set
            {
                cutomerPhoneNumber = value;
                OnPropertyChanged(nameof(CustomerPhoneNumber));
            }
        }
        private string cachierName;
        public string CachierName
        {
            get
            {
                return cachierName;
            }
            set
            {
                cachierName = value;
                OnPropertyChanged(nameof(CachierName));
            }
        }
        private string orderItems;
        public string OrderItems
        {
            get
            {
                return orderItems;
            }
            set
            {
                orderItems = value;
                OnPropertyChanged(nameof(OrderItems));
            }
        }
        private string messages;
        public string Messages
        {
            get
            {
                return messages;
            }
            set
            {
                messages = value;
                OnPropertyChanged(nameof(Messages));
                }
        }
        public ICommand SubmitCommand { get; }

        public ICommand CancelCommand { get; }

        public MakeOrderViewModel(OrdersController _ordersController,NavigationStore navigationStore, Func<DisplayMenuViewModel> CreateDisplayMenuViewModel)
        {
            SubmitCommand = new MakeOrderCommand(this,_ordersController);
            CancelCommand = new NavigateCommand(navigationStore, CreateDisplayMenuViewModel);
        }
    }
}
