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
        public Category Category { get; set; }

    }

    public class CategoryDisplay
    {
        public Category Category { get; set; }
        public List<ItemDisplay> Items { get; set; }
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

            //Make a list of all Items comprised of items added to list and items belonging to meals
            allItems = shoppingList.Meals.SelectMany(m => m.Items).Concat(shoppingList.Items).ToList();

            List<ItemDisplay> newItemList = 
                allItems.OrderBy(x => x.Category.DisplayOrder).ThenBy(x => x.ItemOrder) //Order by Category Order then Item Order
                .GroupBy(x => x, (y, z) => 
                    new ItemDisplay { Name = y.Name, Quantity = z.Count(), Category = y.Category }).ToList(); //Group them while creating new list items with the quantity

            //List<CategoryDisplay> allCats = newItemList.GroupBy(c => c).Select(x => new CategoryDisplay { Category = x. } ).ToList();

            ViewBag.MealItems = newItemList; 

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
