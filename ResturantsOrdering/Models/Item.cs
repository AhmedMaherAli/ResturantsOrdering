using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantsOrdering.Models
{
    public class Item
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        public Item()
        {

        }
        public Item(int price,int availQ,string name)
        {
            Name = name;
            Quantity = availQ;
            Price = price;
        }
        public Item(Item item)
        {
            this.Name = item.Name;
            this.Price = item.Price;

        }

    }
}
