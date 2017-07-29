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
using SimpleShoppingList.DataAccess;

namespace SimpleShoppingList.Controllers
{
    public class ItemsController : Controller
    {
        private ShoppingListContext db = new ShoppingListContext();
        public IShoppingListRepository shoppingListRepository { get; set; }

        // GET: Items
        public ActionResult Index()
        {
            IEnumerable<DataProvider.Models.Item> items = shoppingListRepository.GetItems(); 

            //var items = db.Items.Include(i => i.Category);
            return View(ViewModelMapper.MapItems(items));
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Item item = db.Items.Find(id);
            ItemViewModel item = ViewModelMapper.MapItem(
                shoppingListRepository.GetItem(id));
            if (item == null)
            {
                return HttpNotFound();
            }
            
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(shoppingListRepository.GetCategories(), "CategoryId", "Name");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemId,Name,ItemOrder,CategoryId")] ItemViewModel item)
        {
            if (ModelState.IsValid)
            {
                //db.Items.Add(item);
                //db.SaveChanges();
                shoppingListRepository.AddItem(ViewModelMapper.MapAddUpdateItem(item));
                shoppingListRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(shoppingListRepository.GetCategories(), "CategoryId", "Name", item.CategoryId);
            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Item item = db.Items.Find(id);
            ItemViewModel item = ViewModelMapper.MapItem(
                shoppingListRepository.GetItem(id));
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(shoppingListRepository.GetCategories(), "CategoryId", "Name", item.CategoryId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemId,Name,ItemOrder,CategoryId")] ItemViewModel item)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(item).State = EntityState.Modified;
                //db.SaveChanges();
                shoppingListRepository.UpdateItem(ViewModelMapper.MapAddUpdateItem(item));
                shoppingListRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(shoppingListRepository.GetCategories(), "CategoryId", "Name", item.CategoryId);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
