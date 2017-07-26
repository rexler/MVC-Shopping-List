using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimpleShoppingList.Models;

namespace SimpleShoppingList.Controllers
{
    public class ItemDisplay
    {
        public Item Item { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

    }
    public class ShoppingListsController : Controller
    {
        private ShoppingListContext db = new ShoppingListContext();

        // GET: ShoppingLists
        public ActionResult Index()
        {
            return View(db.ShoppingLists.ToList());
        }

        // GET: ShoppingLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingList shoppingList = db.ShoppingLists.Find(id);
            if (shoppingList == null)
            {
                return HttpNotFound();
            }

            return View(shoppingList);
        }

        // GET: ShoppingLists/View/5
        public ActionResult View(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingList shoppingList = db.ShoppingLists.Find(id);
            if (shoppingList == null)
            {
                return HttpNotFound();
            }

            List<Item> allItems = new List<Item>();

            //Now you will see a contrived way of listing out meal items with their quantities
            //alongside them in the view. 

            List<ItemDisplay> mealItems = new List<ItemDisplay>();

            foreach (Meal m in shoppingList.Meals)
            {
                foreach (Item i in m.Items)
                {
                    allItems.Add(i);

                    
                    //Check if item already exists
                    List<ItemDisplay> matchedItems = mealItems.Where(p => p.Item == i).ToList();
                    if (matchedItems.Count > 0)
                    {
                        //If item already exists, increment its quantity
                        //Then remove and re-add it
                        int quantity = matchedItems[0].Quantity + 1;
                        mealItems.Remove(matchedItems[0]);
                        mealItems.Add(new ItemDisplay { Item = i, Name = i.Name, Quantity = quantity });
                    }
                    else
                    {
                        mealItems.Add(new ItemDisplay { Item = i, Name = i.Name, Quantity = 1 });
                    }
                    
                }
            }

            
            allItems = allItems.OrderBy(i => i.ItemOrder).ToList();
            allItems = allItems.Distinct().ToList();

            //Now loop through the ordered item list and create a new one, 
            //setting the correct quantity
            List<ItemDisplay> newItemList = new List<ItemDisplay>();
            foreach (Item newItem in allItems)
            {
                ItemDisplay matchedItem = mealItems.Where(p => p.Item == newItem).ToList()[0];
                newItemList.Add(matchedItem);
            }
            

            //LINQ version:
            //var newItemList = allItems.OrderBy(x => x.ItemOrder).GroupBy(x => x, (y, z) => new ItemDisplay { Name = y.Name, Quantity = z.Count() }).ToList();

            ViewBag.MealItems = newItemList; //allItems; // mealItems;

            return View(shoppingList);
        }

        // GET: ShoppingLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShoppingListId,Name")] ShoppingList shoppingList)
        {
            if (ModelState.IsValid)
            {
                db.ShoppingLists.Add(shoppingList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shoppingList);
        }

        // GET: ShoppingLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingList shoppingList = db.ShoppingLists.Find(id);
            if (shoppingList == null)
            {
                return HttpNotFound();
            }
            return View(shoppingList);
        }

        // POST: ShoppingLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShoppingListId,Name")] ShoppingList shoppingList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoppingList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shoppingList);
        }

        // GET: ShoppingLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingList shoppingList = db.ShoppingLists.Find(id);
            if (shoppingList == null)
            {
                return HttpNotFound();
            }
            return View(shoppingList);
        }

        // POST: ShoppingLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShoppingList shoppingList = db.ShoppingLists.Find(id);
            db.ShoppingLists.Remove(shoppingList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
