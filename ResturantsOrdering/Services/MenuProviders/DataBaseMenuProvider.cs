using Microsoft.EntityFrameworkCore;
using ResturantsOrdering.DbContexts;
using ResturantsOrdering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantsOrdering.Services.MenuProviders
{
    public class DataBaseMenuProvider 
    {
        ApplicationDbContextFactory applicationDbContextFactory;

        public DataBaseMenuProvider(ApplicationDbContextFactory applicationDbContextFactory)
        {
            this.applicationDbContextFactory = applicationDbContextFactory;
        }
/*
        public  Task< Menu > GetMenus()
        {
            using(ApplicationDbContext _dbContext = applicationDbContextFactory.CreateDbContext())
            {
                return  _dbContext.Menu.FirstOrDefault();
            } 
        }*/
    }
}
