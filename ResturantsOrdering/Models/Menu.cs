﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantsOrdering.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        public List<Item>menu { get; set; }
        public Menu()
        {
        }
       
    }
}
