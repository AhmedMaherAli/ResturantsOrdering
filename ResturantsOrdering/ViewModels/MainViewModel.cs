using ResturantsOrdering.Controllers;
using ResturantsOrdering.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantsOrdering.ViewModels
{
    public class MainViewModel :ViewModelBase
    {

        private readonly NavigationStore navigationStore;
        public ViewModelBase CurrentViewModel => navigationStore.currentViewModel;
        public MainViewModel(NavigationStore _navigationStore)
        {
            navigationStore = _navigationStore;
            navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
