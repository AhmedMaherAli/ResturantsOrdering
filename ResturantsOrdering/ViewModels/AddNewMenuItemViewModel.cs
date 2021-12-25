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
    public class AddNewMenuItemViewModel:ViewModelBase
    {
        private int _price;
        public int ItemPrice
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(ItemPrice));
            }
        }

        private int _itemQuantity;
        public int ItemQuantity
        {
            get
            {
                return _itemQuantity;
            }
            set
            {
                _itemQuantity = value;
                OnPropertyChanged(nameof(ItemQuantity));
            }
        }
        private string _itemName;
        public string ItemName
        {
            get
            {
                return _itemName;
            }
            set
            {
                _itemName = value;
                OnPropertyChanged(nameof(ItemName));
            }
        }
        private string  messages;
        public string  Messages
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

        public AddNewMenuItemViewModel(MenuController _menuController, NavigationStore navigationStore, Func<DisplayMenuViewModel> CreateDisplayMenuViewModel)
        {
            SubmitCommand = new AddMenuItemCommand(this, _menuController);
            CancelCommand = new NavigateCommand(navigationStore, CreateDisplayMenuViewModel);
        }

    }
}
