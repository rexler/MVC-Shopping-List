using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShoppingList.DataProvider.Models
{
    public class ShoppingList
    {
        public virtual int ShoppingListId { get; set; }
        public virtual string Name { get; set; }
        public virtual List<Item> Items { get; set; }
        public virtual List<Meal> Meals { get; set; }
    }
}
