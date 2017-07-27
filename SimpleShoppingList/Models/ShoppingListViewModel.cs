using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleShoppingList.Models
{
    public class ShoppingListViewModel
    {
        public virtual int ShoppingListId { get; set; }
        public virtual string Name { get; set; }
        public virtual List<ItemViewModel> Items { get; set; }
        public virtual List<MealViewModel> Meals { get; set; }
    }
}