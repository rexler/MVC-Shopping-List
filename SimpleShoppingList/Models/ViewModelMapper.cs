using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleShoppingList.Models
{
    public static class ViewModelMapper
    {
        public static List<ShoppingListViewModel> MapShoppingLists(IEnumerable<DataProvider.Models.ShoppingList> shoppingLists)
        {
            List<ShoppingListViewModel> modelView = 
                shoppingLists.Select(x => new ShoppingListViewModel() { ShoppingListId = x.ShoppingListId, Name = x.Name }).ToList();
            return modelView;
        }

        public static DataProvider.Models.ShoppingList MapAddUpdateShoppingList(ShoppingListViewModel shoppingList)
        {
            return new DataProvider.Models.ShoppingList()
            {
                ShoppingListId = shoppingList.ShoppingListId,
                Name = shoppingList.Name
            };
        }
        public static ShoppingListViewModel MapShoppingList(DataProvider.Models.ShoppingList shoppingList)
        {
            return new ShoppingListViewModel()
            {
                ShoppingListId = shoppingList.ShoppingListId,
                Name = shoppingList.Name,
                Items = shoppingList.Items.Select(x => 
                    new ItemViewModel() { ItemId = x.ItemId, Name = x.Name, CategoryId = x.CategoryId }).ToList(),
                Meals = shoppingList.Meals.Select(x =>
                    new MealViewModel() { MealId = x.MealId, Name = x.Name }).ToList()
            };
        }

        public static List<ItemViewModel> MapLists(IEnumerable<DataProvider.Models.Item> items)
        {
            List<ItemViewModel> modelView =
                items.Select(x => new ItemViewModel() { ItemId = x.ItemId, CategoryId = x.CategoryId, Name = x.Name }).ToList();
            return modelView;
        }

        public static DataProvider.Models.Item MapAddUpdateItem(ItemViewModel item)
        {
            return new DataProvider.Models.Item()
            {
                ItemId = item.ItemId,
                CategoryId = item.CategoryId,
                Name = item.Name
            };
        }

        public static ItemViewModel MapItem(DataProvider.Models.Item item)
        {
            return new ItemViewModel()
            {
                ItemId = item.ItemId,
                CategoryId = item.CategoryId,
                Name = item.Name,
                Meals = item.Meals.Select(x =>
                    new MealViewModel() { MealId = x.MealId, Name = x.Name }).ToList(),
                ShoppingLists = item.ShoppingLists.Select(x =>
                    new ShoppingListViewModel() { ShoppingListId = x.ShoppingListId, Name = x.Name }).ToList()
            };
        }
    }
}