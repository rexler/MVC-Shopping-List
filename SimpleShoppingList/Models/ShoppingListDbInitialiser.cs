using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleShoppingList.DataProvider;

namespace SimpleShoppingList.Models
{
    public class ShoppingListDbInitialiser : System.Data.Entity.DropCreateDatabaseAlways<DataProvider.ShoppingListContext>
    {
        protected override void Seed(DataProvider.ShoppingListContext context)
        {
            DataProvider.Models.Category fruitVeg = context.Categories.Add(new DataProvider.Models.Category { Name = "Fruit and Veg", DisplayOrder = 1 });
            DataProvider.Models.Item strawBerries = context.Items.Add(new DataProvider.Models.Item { Name = "Strawberries", Category = fruitVeg, ItemOrder = 1 });
            context.Items.Add(new DataProvider.Models.Item { Name = "Apples", Category = fruitVeg, ItemOrder = 2 });
            context.Items.Add(new DataProvider.Models.Item { Name = "Blueberries", Category = fruitVeg, ItemOrder = 3 });
            DataProvider.Models.Item onion = context.Items.Add(new DataProvider.Models.Item { Name = "Onion", Category = fruitVeg, ItemOrder = 5 });
            DataProvider.Models.Item mushrooms = context.Items.Add(new DataProvider.Models.Item { Name = "Mushrooms", Category = fruitVeg, ItemOrder = 6 });
            DataProvider.Models.Item tomato = context.Items.Add(new DataProvider.Models.Item { Name = "Tomato", Category = fruitVeg, ItemOrder = 4 });

            DataProvider.Models.Item kidneyBeans = context.Items.Add(new DataProvider.Models.Item { Name = "Kidney Beans", Category = fruitVeg, ItemOrder = 5 });

            DataProvider.Models.Category meat = context.Categories.Add(new DataProvider.Models.Category { Name = "Meat", DisplayOrder = 2 });
            DataProvider.Models.Item mince = context.Items.Add(new DataProvider.Models.Item { Name = "Beef Mince", Category = meat, ItemOrder = 1 });
            DataProvider.Models.Item chicken = context.Items.Add(new DataProvider.Models.Item { Name = "Chicken", Category = meat, ItemOrder = 2 });

            DataProvider.Models.Meal spagBol = context.Meals.Add(new DataProvider.Models.Meal
            {
                Name = "Spaghetti Bolognese",
                Items = new List<DataProvider.Models.Item>() { onion, mushrooms, tomato, mince }
            });

            DataProvider.Models.Meal chilli = context.Meals.Add(new DataProvider.Models.Meal
            {
                Name = "Chilli",
                Items = new List<DataProvider.Models.Item>() { onion, tomato, mince, kidneyBeans }
            });

            DataProvider.Models.Meal chickMushroom = context.Meals.Add(new DataProvider.Models.Meal
            {
                Name = "Chicken and Mushroom",
                Items = new List<DataProvider.Models.Item>() { onion, chicken }
            });

            context.ShoppingLists.Add(new DataProvider.Models.ShoppingList
            {
                Name = "Week 1",
                Items = new List<DataProvider.Models.Item>() { onion, strawBerries },
                Meals = new List<DataProvider.Models.Meal>() { spagBol, chilli, chickMushroom }
            });

            base.Seed(context);
        }
    }
}