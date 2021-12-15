﻿using ResturantsOrdering.Controllers;
using ResturantsOrdering.Models;
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
        public ICommand OpenOrderPageCommand { get; }
        public MenuController menuController;
        public DisplayMenuViewModel()
        {
            menu = new ObservableCollection<ItemViewModel>();
            menuController = new MenuController();
            foreach(Item _item in menuController.GetMenu())
            {
                menu.Add(new ItemViewModel(_item));
            }
        }
    }
}