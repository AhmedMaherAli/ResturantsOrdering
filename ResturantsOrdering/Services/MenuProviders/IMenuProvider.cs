using ResturantsOrdering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantsOrdering.Services.MenuProviders
{
    public interface IMenuProvider
    {

        Task<Menu> GetMenus();
          
    }
}
