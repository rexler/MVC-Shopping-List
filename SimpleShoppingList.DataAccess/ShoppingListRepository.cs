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
        public ShoppingListContext context { get; set; }        

        public void Save()
        {
            this.context.SaveChanges();
        }

        #region Shopping Lists
        public IEnumerable<ShoppingList> GetShoppingLists()
        {
            return context.ShoppingLists.ToList();
        }
        public void AddShoppingList(ShoppingList shoppingList)
        {
            context.ShoppingLists.Add(shoppingList);
        }

        public ShoppingList GetShoppingList(int? id)
        {
            return context.ShoppingLists.Find(id);
        }
        public List<ItemDisplay> GetShoppingListSortedItems(int? id)
        {
            ShoppingList shoppingList = context.ShoppingLists.Find(id);
            //Get a list of all items comprised of the list items and meal items
            List<Item> allItems = shoppingList.Meals.SelectMany(m => m.Items).Concat(shoppingList.Items).ToList();
            List<ItemDisplay> newItemList =
                allItems.OrderBy(x => x.Category.DisplayOrder).ThenBy(x => x.ItemOrder) //Order by Category Order then Item Order
                .GroupBy(x => x, (y, z) =>
                    new ItemDisplay {
                        Name = y.Name,
                        Quantity = z.Count(),
                        Category = y.Category
                    }).ToList(); //Group them while creating new list items with the quantity
            return newItemList;
        }

        public void UpdateShoppingList(ShoppingList shoppingList)
        {
            context.Entry(shoppingList).State = System.Data.Entity.EntityState.Modified;
        }

        public void DeleteShoppingList(int? id)
        {
            ShoppingList shoppingList = context.ShoppingLists.Find(id);
            context.ShoppingLists.Remove(shoppingList);
        }
        public void DeleteItemFromShoppingList(int shoppingListID, int itemID)
        {
            ShoppingList list = context.ShoppingLists.Find(shoppingListID);
            Item item = list.Items.Where(x => x.ItemId == itemID).First();
            list.Items.Remove(item);
        }
        #endregion

        #region Items
        public IEnumerable<Item> GetItems()
        {
            return context.Items.ToList();
        }

        public void AddItem(Item item)
        {
            context.Items.Add(item);
        }

        public Item GetItem(int? id)
        {
            return context.Items.Find(id);
        }

        public void UpdateItem(Item item)
        {
            context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
        public void DeleteItem(int? id)
        {
            Item item = context.Items.Find(id);
            context.Items.Remove(item);
        }
        #endregion

        #region Categories
        public IEnumerable<Category> GetCategories()
        {
            return context.Categories.ToList();
        }

        public void AddCategory(Category cat)
        {
            context.Categories.Add(cat);
        }

        public Category GetCategory(int? id)
        {
            return context.Categories.Find(id);
        }

        public void UpdateCategory(Category cat)
        {
            context.Entry(cat).State = System.Data.Entity.EntityState.Modified;
        }
        public void DeleteCategory(int? id)
        {
            Category cat = context.Categories.Find(id);
            context.Categories.Remove(cat);
        }
        #endregion

        #region Meals
        public IEnumerable<Meal> GetMeals()
        {
            return context.Meals.ToList();
        }

        public void AddMeal(Meal meal)
        {
            context.Meals.Add(meal);
        }

        public Meal GetMeal(int? id)
        {
            return context.Meals.Find(id);
        }

        public void UpdateMeal(Meal meal)
        {
            context.Entry(meal).State = System.Data.Entity.EntityState.Modified;
        }
        public void DeleteMeal(int? id)
        {
            Meal meal = context.Meals.Find(id);
            context.Meals.Remove(meal);
        }

        #endregion


    }
}
