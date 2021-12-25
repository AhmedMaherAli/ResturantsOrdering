using ResturantsOrdering.Commands;
using ResturantsOrdering.Controllers;
using ResturantsOrdering.Models;
using ResturantsOrdering.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ResturantsOrdering.ViewModels
{
    public class DisplayMenuViewModel:ViewModelBase
    {

        private readonly ObservableCollection<ItemViewModel> menu;
        public IEnumerable<ItemViewModel> Menu => menu;
        public ICommand OpenAddItemCommand { get; }
        public ICommand OpenOrderPageCommand { get; }
        public MenuController menuController;
        public DisplayMenuViewModel(NavigationStore navigationStore, Func<MakeOrderViewModel> CreateMakeOrderViewModel, Func<AddNewMenuItemViewModel> addNewMenuItemViewModel, MenuController _menuController)
        {
            OpenAddItemCommand = new NavigateCommand(navigationStore, addNewMenuItemViewModel);
            OpenOrderPageCommand = new NavigateCommand(navigationStore, CreateMakeOrderViewModel);
            menuController = _menuController;
            menu = new ObservableCollection<ItemViewModel>();
            foreach(Item _item in menuController.GetMenu())
            {
                menu.Add(new ItemViewModel(_item));
            }
        }
    }
}
