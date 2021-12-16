using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantsOrdering.Models
{
    public class Item
    {

        static int Items = 0;
        public int Id { get; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        
        public Item(int price,int availQ,string name)
        {

            Id = ++Items;
            Name = name;
            Quantity = availQ;
            Price = price;
        }

    }
}
