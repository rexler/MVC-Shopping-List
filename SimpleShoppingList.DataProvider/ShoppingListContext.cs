using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShoppingList.DataProvider
{
    public class ShoppingListContext : DbContext
    {
        public ShoppingListContext() : base("name=ShoppingListContext")
        {
        }
        public System.Data.Entity.DbSet<SimpleShoppingList.DataProvider.Models.ShoppingList> ShoppingLists { get; set; }

        public System.Data.Entity.DbSet<SimpleShoppingList.DataProvider.Models.Item> Items { get; set; }

        public System.Data.Entity.DbSet<SimpleShoppingList.DataProvider.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<SimpleShoppingList.DataProvider.Models.Meal> Meals { get; set; }

        
    }
}
