﻿using System;
using System.Configuration;
using System.Data;
using System.Linq;
using ResturantsOrdering.Models;
using ResturantsOrdering.Controllers;
using System.Windows;
using ResturantsOrdering.ViewModels;
using ResturantsOrdering.Stores;

namespace ResturantsOrdering
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore navigationStore;
        private readonly OrdersController ordersController;
        private readonly MenuController menuController;
        public MakeOrderViewModel makeOrderViewModel;
        public DisplayMenuViewModel displayMenuViewModel;
        public ReceiptViewModel receiptViewModel;
        public App()
        {
            menuController = new MenuController();
            ordersController = new OrdersController(menuController);
            navigationStore = new NavigationStore();
            makeOrderViewModel = new MakeOrderViewModel(ordersController, navigationStore, CreateDisplayMenuViewModel, CreateReciptViewModel);
            displayMenuViewModel = new DisplayMenuViewModel(navigationStore, CreateMakeOrderViewModel, menuController);
            receiptViewModel = new ReceiptViewModel(makeOrderViewModel, navigationStore, CreateDisplayMenuViewModel);
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            navigationStore.CurrentViewModel = CreateDisplayMenuViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
        private MakeOrderViewModel CreateMakeOrderViewModel()
        {

            return makeOrderViewModel;
        }

        private DisplayMenuViewModel CreateDisplayMenuViewModel()
        {
            return displayMenuViewModel;
        }
        private ReceiptViewModel CreateReciptViewModel()
        {
            ordersController.ConfirmOrder(ordersController.CurrentOrder);
            return receiptViewModel;
        }
    }
}

/*

OrdersController ordersController =new OrdersController();
            MenuController menuController = new MenuController();
            List<Item> menu = menuController.GetMenu();
            List<Item> ItemsList = new List<Item>();
            ItemsList.Add(new Item(0, 30, "Small Sea Runch"));
            Order order = ordersController.CreateOrder("Ahmed Maher", "0123456789", "Mohamed Alaa", ItemsList);
            System.Threading.Thread.Sleep(2000);
            ordersController.CalculateOrderServiceTime(order);
            string message=ordersController .MakeOrder(order);
            Console.WriteLine(message);

            List<Item> ItemsList2 = new List<Item>();
            ItemsList.Add(new Item(0, 8, "Small Sea Runch"));
            Order order2 = ordersController.CreateOrder("Ahmed Maher", "0123456789", "Mohamed Alaa",  ItemsList);
            System.Threading.Thread.Sleep(2000);
            ordersController.CalculateOrderServiceTime(order2);
            string message2 = ordersController.MakeOrder(order2);
            Console.WriteLine(message2);
            int length = ordersController.GetNumberOfTotalOrders();
            Console.WriteLine(length);


        
 */