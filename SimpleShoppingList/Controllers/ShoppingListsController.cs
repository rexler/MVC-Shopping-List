using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimpleShoppingList.Models;
using SimpleShoppingList.IDataAccess;
using SimpleShoppingList.DataProvider;
using SimpleShoppingList.DataAccess;
using SimpleShoppingList.DataProvider.Models;

namespace SimpleShoppingList.Controllers
{
    

    public class CategoryDisplay
    {
        public DataProvider.Models.Category Category { get; set; }
        public List<ItemDisplay> Items { get; set; }
    }

    public class ShoppingListsController : Controller
    {
        private Models.ShoppingListContext db = new Models.ShoppingListContext();
        public IShoppingListRepository shoppingListRepository { get; set; }

        // GET: ShoppingLists
        public ActionResult Index()
        {
            IEnumerable<DataProvider.Models.ShoppingList> shoppingLists = shoppingListRepository.GetShoppingLists();
            return View(ViewModelMapper.MapShoppingLists(shoppingLists));
        }

        // GET: ShoppingLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingListViewModel shoppingList = ViewModelMapper.MapShoppingList(
                shoppingListRepository.GetShoppingList(id));
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
            //ShoppingList shoppingList = db.ShoppingLists.Find(id);
            ShoppingListViewModel shoppingList = ViewModelMapper.MapShoppingList(
                shoppingListRepository.GetShoppingList(id));
            if (shoppingList == null)
            {
                return HttpNotFound();
            }

            List<ItemDisplay> newItemList = shoppingListRepository.GetShoppingListSortedItems(id);
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
        public ActionResult Create([Bind(Include = "ShoppingListId,Name")] ShoppingListViewModel shoppingList)
        {
            if (ModelState.IsValid)
            {
                shoppingListRepository.AddShoppingList(ViewModelMapper.MapAddUpdateShoppingList(shoppingList));
                shoppingListRepository.Save();
                //db.ShoppingLists.Add(shoppingList);
                //db.SaveChanges();
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
            //ShoppingList shoppingList = db.ShoppingLists.Find(id);
            ShoppingListViewModel shoppingList = ViewModelMapper.MapShoppingList(
                shoppingListRepository.GetShoppingList(id));
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
        public ActionResult Edit([Bind(Include = "ShoppingListId,Name")] ShoppingListViewModel shoppingList)
        {
            if (ModelState.IsValid)
            {
                shoppingListRepository.UpdateShoppingList(ViewModelMapper.MapAddUpdateShoppingList(shoppingList));
                shoppingListRepository.Save();
                //db.Entry(shoppingList).State = EntityState.Modified;
                //db.SaveChanges();
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
            //SimpleShoppingList.Models.ShoppingList shoppingList = db.ShoppingLists.Find(id);
            
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
            SimpleShoppingList.Models.ShoppingList shoppingList = db.ShoppingLists.Find(id);
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
