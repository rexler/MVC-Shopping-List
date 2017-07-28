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

    }
}
