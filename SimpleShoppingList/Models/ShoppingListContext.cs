using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleShoppingList.Models
{
    public class ShoppingListContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ShoppingListContext() : base("name=ShoppingListContext")
        {
        }

        public System.Data.Entity.DbSet<SimpleShoppingList.Models.Item> Items { get; set; }

        public System.Data.Entity.DbSet<SimpleShoppingList.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<SimpleShoppingList.Models.Meal> Meals { get; set; }

        public System.Data.Entity.DbSet<SimpleShoppingList.Models.ShoppingList> ShoppingLists { get; set; }
    }
}
