using ResturantsOrdering.Controllers;
using ResturantsOrdering.Models;
using ResturantsOrdering.Stores;
using ResturantsOrdering.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantsOrdering.Commands
{
    public class AddMenuItemCommand : CommandBase
    {
        private readonly MenuController _menuController;
        private readonly AddNewMenuItemViewModel _addNewMenuItemViewModel;


        public AddMenuItemCommand(AddNewMenuItemViewModel addNewMenuItemViewModel, MenuController menuController)
        {
            _addNewMenuItemViewModel = addNewMenuItemViewModel;
            _menuController = menuController;
        }

        public override void Execute(object parameter)
        {
            string message = _menuController.AddNewItem(_addNewMenuItemViewModel.ItemName, _addNewMenuItemViewModel.ItemQuantity, _addNewMenuItemViewModel.ItemPrice);
            _addNewMenuItemViewModel.Messages = message;
        }
    }
}
