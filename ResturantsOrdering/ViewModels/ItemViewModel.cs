using ResturantsOrdering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantsOrdering.ViewModels
{
    public class ItemViewModel:ViewModelBase
    {
        private readonly Item item;

        public int ItemId => item.Id;
        public string ItemName => item.Name;
        public int ItemQuantity => item.Quantity;
        public int ItemPrice => item.Price;

        public ItemViewModel(Item _Item)
        {
            item = _Item;
        }
    }
}
