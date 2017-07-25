﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleShoppingList.Models
{
    public class ShoppingListDbInitialiser : System.Data.Entity.DropCreateDatabaseAlways<ShoppingListContext>
    {
        protected override void Seed(ShoppingListContext context)
        {
            Category fruitVeg = context.Categories.Add(new Category { Name = "Fruit and Veg" });
            context.Items.Add(new Item { Name = "Strawberries", Category = fruitVeg, ItemOrder = 1 });
            context.Items.Add(new Item { Name = "Apples", Category = fruitVeg, ItemOrder = 2 });
            context.Items.Add(new Item { Name = "Blueberries", Category = fruitVeg, ItemOrder = 3 });
            Item onion = context.Items.Add(new Item { Name = "Onion", Category = fruitVeg, ItemOrder = 5 });
            Item mushrooms = context.Items.Add(new Item { Name = "Mushrooms", Category = fruitVeg, ItemOrder = 6 });
            Item tomato = context.Items.Add(new Item { Name = "Tomato", Category = fruitVeg, ItemOrder = 4 });

            Item kidneyBeans = context.Items.Add(new Item { Name = "Kidney Beans", Category = fruitVeg, ItemOrder = 5 });

            Category meat = context.Categories.Add(new Category { Name = "Meat" });
            Item mince = context.Items.Add(new Item { Name = "Beef Mince", Category = meat, ItemOrder = 1 });

            context.Meals.Add(new Meal
            {
                Name = "Spaghetti Bolognese",
                Items = new List<Item>() { onion, mushrooms, tomato, mince }
            });

            context.Meals.Add(new Meal
            {
                Name = "Chilli",
                Items = new List<Item>() { onion, tomato, mince, kidneyBeans }
            });

            base.Seed(context);
        }
    }
}