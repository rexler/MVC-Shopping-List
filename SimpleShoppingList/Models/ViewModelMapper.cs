﻿using SimpleShoppingList.DataProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleShoppingList.Models
{
    public static class ViewModelMapper
    {
        public static List<ShoppingListViewModel> MapShoppingLists(IEnumerable<ShoppingList> shoppingLists)
        {
            List<ShoppingListViewModel> modelView = 
                shoppingLists.Select(x => new ShoppingListViewModel() { ShoppingListId = x.ShoppingListId, Name = x.Name }).ToList();
            return modelView;
        }

        public static ShoppingList MapAddUpdateShoppingList(ShoppingListViewModel shoppingList)
        {
            return new ShoppingList()
            {
                ShoppingListId = shoppingList.ShoppingListId,
                Name = shoppingList.Name
            };
        }
        public static ShoppingListViewModel MapShoppingList(ShoppingList shoppingList)
        {
            return new ShoppingListViewModel()
            {
                /* TODO: Need to map list of meal items so ShoppingList view will work */
                ShoppingListId = shoppingList.ShoppingListId,
                Name = shoppingList.Name,
                Items = shoppingList.Items.Select(x => 
                    new ItemViewModel() { ItemId = x.ItemId, Name = x.Name, CategoryId = x.CategoryId,
                        Category = new CategoryViewModel()
                        {
                            CategoryId = x.CategoryId, Name = x.Category.Name, DisplayOrder = x.Category.DisplayOrder
                        } }).ToList(),
                Meals = shoppingList.Meals.Select(x =>
                    new MealViewModel() {
                        MealId = x.MealId,
                        Name = x.Name,
                        Items = x.Items.Select(i => 
                            new ItemViewModel()
                            {
                                ItemId = i.ItemId,
                                Name = i.Name,
                                CategoryId = i.CategoryId,
                                Category = new CategoryViewModel()
                                {
                                    CategoryId = i.CategoryId,
                                    Name = i.Category.Name
                                }
                            }).ToList()
                    }).ToList()
            };
        }

        public static List<ItemViewModel> MapItems(IEnumerable<Item> items)
        {
            List<ItemViewModel> modelView =
                items.Select(x => new ItemViewModel()
                {
                    ItemId = x.ItemId, CategoryId = x.CategoryId, Name = x.Name, ItemOrder = x.ItemOrder,
                    Category = new CategoryViewModel() { Name = x.Category.Name }
                }).ToList();
            return modelView;
        }

        public static Item MapAddUpdateItem(ItemViewModel item)
        {
            return new Item()
            {
                ItemId = item.ItemId,
                CategoryId = item.CategoryId,
                Name = item.Name,
                ItemOrder = item.ItemOrder
            };
        }

        public static ItemViewModel MapItem(Item item)
        {
            return new ItemViewModel()
            {
                ItemId = item.ItemId,
                CategoryId = item.CategoryId,
                Category = new CategoryViewModel() { Name = item.Category.Name },
                ItemOrder = item.ItemOrder,
                Name = item.Name,
                Meals = item.Meals.Select(x =>
                    new MealViewModel() { MealId = x.MealId, Name = x.Name }).ToList(),
                ShoppingLists = item.ShoppingLists.Select(x =>
                    new ShoppingListViewModel() { ShoppingListId = x.ShoppingListId, Name = x.Name }).ToList()
            };
        }

        public static List<CategoryViewModel> MapCategories(IEnumerable<Category> categories)
        {
            List<CategoryViewModel> modelView =
                categories.Select(x => new CategoryViewModel()
                {
                    Name = x.Name,
                    CategoryId = x.CategoryId,
                    DisplayOrder = x.DisplayOrder
                }).ToList();
            return modelView;
        }

        public static Category MapAddUpdateCategory(CategoryViewModel category)
        {
            return new Category()
            {
                CategoryId = category.CategoryId,
                DisplayOrder = category.DisplayOrder,
                Name = category.Name
            };
        }

        public static CategoryViewModel MapCategory(Category category)
        {
            return new CategoryViewModel()
            {
                CategoryId = category.CategoryId,
                DisplayOrder = category.DisplayOrder,
                Name = category.Name
            };
        }

        public static List<MealViewModel> MapMeals(IEnumerable<Meal> meals)
        {
            List<MealViewModel> modelView =
                meals.Select(x => new MealViewModel()
                {
                    Name = x.Name,
                    MealId = x.MealId
                }).ToList();
            return modelView;
        }

        public static Meal MapAddUpdateMeal(MealViewModel meal)
        {
            return new Meal()
            {
                MealId = meal.MealId,
                Name = meal.Name
            };
        }

        public static MealViewModel MapMeal(Meal meal)
        {
            return new MealViewModel()
            {
                MealId = meal.MealId,
                Name = meal.Name,
                Items = meal.Items.Select(x => new ItemViewModel()
                {
                    Name = x.Name,
                    ItemId = x.ItemId
                }).ToList()
            };
        }
    }
}