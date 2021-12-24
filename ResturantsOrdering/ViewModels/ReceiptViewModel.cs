using ResturantsOrdering.Commands;
using ResturantsOrdering.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ResturantsOrdering.ViewModels
{
    public class ReceiptViewModel:ViewModelBase
    {
        MakeOrderViewModel makeOrderViewModel;
        public ReceiptViewModel(MakeOrderViewModel _makeOrderViewModel,NavigationStore navigationStore, Func<DisplayMenuViewModel> CreateDisplayMenuViewModel)
        {
            makeOrderViewModel = _makeOrderViewModel;

            CancelCommand = new NavigateCommand(navigationStore, CreateDisplayMenuViewModel);
        }
        public string AllReceipt => makeOrderViewModel.AllReceipt;

        public ICommand CancelCommand { get; }

    }
}
