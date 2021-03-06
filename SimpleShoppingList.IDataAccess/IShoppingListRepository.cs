﻿using System;
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
        List<ItemDisplay> GetShoppingListSortedItems(int? id);
        void AddShoppingList(ShoppingList shoppingList);
        ShoppingList GetShoppingList(int? id);
        void UpdateShoppingList(ShoppingList shoppingList);
        void DeleteShoppingList(int? id);
        void DeleteItemFromShoppingList(int shoppingListID, int itemID);
        IEnumerable<Category> GetCategories();
        void AddCategory(Category cat);
        Category GetCategory(int? id);
        void UpdateCategory(Category cat);
        void DeleteCategory(int? id);
        IEnumerable<Item> GetItems();
        void AddItem(Item item);
        Item GetItem(int? id);
        IEnumerable<Item> GetItemsByName(string search);
        void UpdateItem(Item item);
        void DeleteItem(int? id);
        IEnumerable<Meal> GetMeals();
        void AddMeal(Meal meal);
        Meal GetMeal(int? id);
        void UpdateMeal(Meal meal);
        void DeleteMeal(int? id);
        void Save();
    }
}
