using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleShoppingList.DataProvider.Models;

namespace SimpleShoppingList.IDataAccess
{
    public interface IShoppingListRepository
    {
        IEnumerable<ShoppingList> GetShoppingLists();
        void AddShoppingList(ShoppingList shoppingList);
        ShoppingList GetShoppingList(int? id);
        void UpdateShoppingList(ShoppingList shoppingList);
        void Save();
    }
}
