using SimpleShoppingList.DataProvider;
using SimpleShoppingList.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleShoppingList.IDataAccess;

namespace SimpleShoppingList.DataAccess
{
    public class ShoppingListRepository : IShoppingListRepository
    {
        private ShoppingListContext context;

        public ShoppingListRepository(ShoppingListContext context)
        {
            this.context = context;
        }
        public IEnumerable<ShoppingList> GetShoppingLists()
        {
            return context.ShoppingLists.ToList();
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void AddShoppingList(ShoppingList shoppingList)
        {
            context.ShoppingLists.Add(shoppingList);
        }

        public ShoppingList GetShoppingList(int? id)
        {
            return context.ShoppingLists.Find(id);
        }

        public void UpdateShoppingList(ShoppingList shoppingList)
        {
            context.Entry(shoppingList).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
