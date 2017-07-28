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
        IEnumerable<Category> GetCategories();
        void AddCategory(Category cat);
        Category GetCategory(int? id);
        void UpdateCategory(Category cat);
        IEnumerable<Item> GetItems();
        void AddItem(Item item);
        Item GetItem(int? id);
        void UpdateItem(Item item);
        IEnumerable<Meal> GetMeals();
        void AddMeal(Meal meal);
        Meal GetMeal(int? id);
        void UpdateMeal(Meal meal);
        void Save();
    }
}
