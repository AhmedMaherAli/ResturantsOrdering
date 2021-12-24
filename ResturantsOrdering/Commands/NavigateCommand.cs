using ResturantsOrdering.Controllers;
using ResturantsOrdering.Stores;
using ResturantsOrdering.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantsOrdering.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationStore navigationStore;
        private readonly Func<ViewModelBase> CreateViewModel;

        public NavigateCommand(NavigationStore _navigationStore,Func<ViewModelBase> createViewModel)
        {
            navigationStore = _navigationStore;
            CreateViewModel = createViewModel;
        }

        public override void Execute(object parameter)
        {
            navigationStore.CurrentViewModel = CreateViewModel();
        }
    }
}
