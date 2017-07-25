using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleShoppingList.Models
{
    public class ShoppingList
    {
        public virtual int ShoppingListId { get; set; }
        public virtual string Name { get; set; }
        public virtual List<Item> Items { get; set; }
        public virtual List<Meal> Meals { get; set; }
    }
}