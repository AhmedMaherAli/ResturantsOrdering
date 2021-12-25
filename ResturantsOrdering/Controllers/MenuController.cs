using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResturantsOrdering.DbContexts;
using ResturantsOrdering.Models;

namespace ResturantsOrdering.Controllers
{
    public class MenuController
    {
        public Menu Menu;
        private readonly ApplicationDbContextFactory _applicationDbContextFactory;
        public MenuController(ApplicationDbContextFactory applicationDbContextFactory)
        {
            _applicationDbContextFactory = applicationDbContextFactory;
            InitializeMenu();
        }
        public void InitializeMenu()
        {
            Menu = new Menu(); 
            using (ApplicationDbContext _dbContext = _applicationDbContextFactory.CreateDbContext())
            {
                Menu.menu = _dbContext.Item.Where(u => u.MenuId == 1).ToList();
            }
        }
        public Item GetItemFromMenuByName(string ItemName)
        {
            Item StoredItem = Menu.menu.FirstOrDefault(item => item.Name == ItemName);
            return StoredItem;
        }
        public Item GetItemFromMenuById(int Id)
        {
            Item StoredItem = Menu.menu.FirstOrDefault(item => item.Id == Id);
            return StoredItem;
        }
        public List<Item> GetMenu()
        {
            return Menu.menu;
        }
        public string AddNewItem(string name, int availQuantity, int price)
        {
            string message;
            if (name == null) 
            {
                message = "You have to provide item name.";
                return message; 
            }
            if (Menu.menu.FirstOrDefault(item => item.Name==name)!=null)
            {
                message = "This product exists already, you can append it's availabel quantity.";
                return message;
            }
            using (ApplicationDbContext _dbContext = _applicationDbContextFactory.CreateDbContext())
            {
                Item NewItem = new Item(price, availQuantity, name);
                Menu MenuFromDb = _dbContext.Menu.FirstOrDefault(m => m.MenuId == 1);
                MenuFromDb.menu.Add(NewItem);
                _dbContext.Menu.Update(MenuFromDb);
                _dbContext.SaveChanges();
                Menu.menu = _dbContext.Item.Where(u => u.MenuId == 1).ToList();
            }
            
            message = "Item is added to the menu successfully.";
            return message;
        }
        public string AppendItemQuantity(string name, int addedQuantity)
        {
            string message;
            Item StoredItem = Menu.menu.FirstOrDefault(item => item.Name == name);
            if (StoredItem != null)
            {
                StoredItem.Quantity += addedQuantity;
                message = "Quantity Added to it successfully.";
                return message;
            }
            message = "There is no item with this name, Call AddNewItem method to add it to the menu.";
            return message;
        }
    }
}


/*
 *          Menu.menu.Add(new Item(50, 35, "Small Sea Runch"));
            Menu.menu.Add(new Item(80, 35, "Medium Sea Runch"));
            Menu.menu.Add(new Item(100, 35, "Large Sea Runch"));

            Menu.menu.Add(new Item(45, 35, "Small Chicken barbecue"));
            Menu.menu.Add(new Item(75, 35, "Medium Chicken barbecue"));
            Menu.menu.Add(new Item(95, 35, "Large Chicken barbecue"));

            Menu.menu.Add(new Item(43, 35, "Small Mix Cheese"));
            Menu.menu.Add(new Item(72, 35, "Medium Mix Cheese"));
            Menu.menu.Add(new Item(92, 35, "Large Mix Cheese"));


            Menu.menu.Add(new Item(72, 35, "Medium Chicken Burger"));
            Menu.menu.Add(new Item(72, 35, "Medium Meat Burger"));

            Menu.menu.Add(new Item(43, 35, "Spicy Buffalo Sauce"));
            Menu.menu.Add(new Item(72, 35, "Creamy Ranch Sauce"));
            Menu.menu.Add(new Item(43, 35, "Honey Mustard Sauce"));
            Menu.menu.Add(new Item(72, 35, "Tangy Barbecue Sauce"));

            Menu.menu.Add(new Item(80, 35, "Chicken Shawarma Fatta"));
            Menu.menu.Add(new Item(80, 35, "Meat Shawarma Fatta"));
            using (ApplicationDbContext _dbContext = _applicationDbContextFactory.CreateDbContext())
            {
                foreach (Item item in Menu.menu)
                {
                    _dbContext.Item.Add(item);
                }
                _dbContext.Menu.Add(Menu);
                _dbContext.SaveChanges();
            }




using (ApplicationDbContext _dbContext = _applicationDbContextFactory.CreateDbContext())
            {
                 Menu.menu=_dbContext.Item.Where(u => u.MenuId == 1).ToList();
            }
 */