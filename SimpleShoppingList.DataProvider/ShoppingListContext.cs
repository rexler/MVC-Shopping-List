using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using SimpleShoppingList.DataProvider.Models;

namespace SimpleShoppingList.DataProvider
{
    public class ShoppingListContext : DbContext
    {
        public ShoppingListContext() : base("name=ShoppingListContext")
        {
        }
        public System.Data.Entity.DbSet<ShoppingList> ShoppingLists { get; set; }

        public System.Data.Entity.DbSet<Item> Items { get; set; }

        public System.Data.Entity.DbSet<Category> Categories { get; set; }

        public System.Data.Entity.DbSet<Meal> Meals { get; set; }

        
    }
}
