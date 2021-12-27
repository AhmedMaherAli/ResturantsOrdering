using ResturantsOrdering.Controllers;
using ResturantsOrdering.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantsOrdering.Commands
{
    public class RemoveItemCommand:CommandBase
    {
        private readonly MenuController _menuController;
        public DisplayMenuViewModel _displayMenuViewModel;

        public RemoveItemCommand( DisplayMenuViewModel displayMenuViewModel ,MenuController menuController)
        {
            _menuController = menuController;
            _displayMenuViewModel = displayMenuViewModel;
        }

        public override void Execute(object parameter)
        {
            _menuController.RemoveMenuItem(_displayMenuViewModel.ItemIdToRemove);
            _displayMenuViewModel.ReloadMenu();
        }
    }
}
