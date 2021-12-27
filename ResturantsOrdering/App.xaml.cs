using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ResturantsOrdering.Models;
using ResturantsOrdering.Controllers;
using System.Windows;
using ResturantsOrdering.ViewModels;
using ResturantsOrdering.Stores;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ResturantsOrdering.DbContexts;

namespace ResturantsOrdering
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public const string CONNECTIONSTRING = "Server=(localdb)\\MSSQLLocalDB;Database=ResturatsOrdering;Trusted_Connection=True;MultipleActiveResultSets=True";
        private readonly ApplicationDbContextFactory applicationDbContextFactory;
        private readonly NavigationStore navigationStore;
        private readonly OrdersController ordersController;
        private readonly MenuController menuController;
        public MakeOrderViewModel makeOrderViewModel;
        public DisplayMenuViewModel displayMenuViewModel;
        public ReceiptViewModel receiptViewModel;
        public AddNewMenuItemViewModel addNewMenuItemViewModel;
        public App()
        {
            applicationDbContextFactory = new ApplicationDbContextFactory(CONNECTIONSTRING);
            menuController = new MenuController(applicationDbContextFactory);
            ordersController = new OrdersController(menuController,applicationDbContextFactory);
            navigationStore = new NavigationStore();
            makeOrderViewModel = new MakeOrderViewModel(ordersController, navigationStore, CreateDisplayMenuViewModel, CreateReciptViewModel);

            addNewMenuItemViewModel = new AddNewMenuItemViewModel(menuController, navigationStore, CreateDisplayMenuViewModel);
            displayMenuViewModel = new DisplayMenuViewModel(navigationStore, CreateMakeOrderViewModel, CreateAddItemViewModel, menuController);
            receiptViewModel = new ReceiptViewModel(makeOrderViewModel, navigationStore, CreateDisplayMenuViewModel);

        }

        protected override void OnStartup(StartupEventArgs e)
        {

            DbContextOptions dbContextOptions = new DbContextOptionsBuilder().UseSqlServer(CONNECTIONSTRING).Options;
            using (ApplicationDbContext dbContext = new ApplicationDbContext(dbContextOptions))
            {
                dbContext.Database.Migrate();
            }

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
            displayMenuViewModel = new DisplayMenuViewModel(navigationStore, CreateMakeOrderViewModel, CreateAddItemViewModel, menuController);
            return displayMenuViewModel;
        }
        private ReceiptViewModel CreateReciptViewModel()
        {

            ordersController.ConfirmOrder(ordersController.CurrentOrder);
            return receiptViewModel;
        }
        private AddNewMenuItemViewModel CreateAddItemViewModel()
        {
            return addNewMenuItemViewModel;
        }
    }
}

/*
"Server=(localdb)\\MSSQLLocalDB;Database=ResturatsOrdering;Trusted_Connection=True;MultipleActiveResultSets=True"

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



        dotnet publish -c Release --self-contained
 */