using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleShoppingList.DataProvider.Models;

namespace SimpleShoppingList.Models
{
    public class ShoppingListDbInitialiser : System.Data.Entity.DropCreateDatabaseAlways<DataProvider.ShoppingListContext>
    {
        protected override void Seed(DataProvider.ShoppingListContext context)
        {
            Category fruitVeg = context.Categories.Add(new Category { Name = "Fruit and Veg", DisplayOrder = 1 });
            Item strawBerries = context.Items.Add(new Item { Name = "Strawberries", Category = fruitVeg, ItemOrder = 1 });
            Item apples = context.Items.Add(new Item { Name = "Apples", Category = fruitVeg, ItemOrder = 2 });
            Item blueberries = context.Items.Add(new Item { Name = "Blueberries", Category = fruitVeg, ItemOrder = 3 });
            Item onion = context.Items.Add(new Item { Name = "Onion", Category = fruitVeg, ItemOrder = 5 });
            Item mushrooms = context.Items.Add(new Item { Name = "Mushrooms", Category = fruitVeg, ItemOrder = 6 });
            Item tomato = context.Items.Add(new Item { Name = "Tomato", Category = fruitVeg, ItemOrder = 4 });

            Item kidneyBeans = context.Items.Add(new Item { Name = "Kidney Beans", Category = fruitVeg, ItemOrder = 5 });

            Category meat = context.Categories.Add(new Category { Name = "Meat", DisplayOrder = 2 });
            Item mince = context.Items.Add(new Item { Name = "Beef Mince", Category = meat, ItemOrder = 1 });
            Item chicken = context.Items.Add(new Item { Name = "Chicken", Category = meat, ItemOrder = 2 });

            Meal spagBol = context.Meals.Add(new Meal
            {
                Name = "Spaghetti Bolognese",
                Items = new List<Item>() { onion, mushrooms, tomato, mince }
            });

            Meal chilli = context.Meals.Add(new Meal
            {
                Name = "Chilli",
                Items = new List<Item>() { onion, tomato, mince, kidneyBeans }
            });

            Meal chickMushroom = context.Meals.Add(new Meal
            {
                Name = "Chicken and Mushroom",
                Items = new List<Item>() { onion, chicken }
            });

            context.ShoppingLists.Add(new ShoppingList
            {
                Name = "Week 1",
                Items = new List<Item>() { onion, strawBerries, apples, blueberries },
                Meals = new List<Meal>() { spagBol, chilli, chickMushroom }
            });

            base.Seed(context);
        }
    }
}