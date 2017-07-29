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
using SimpleShoppingList.DataProvider.Models;

namespace SimpleShoppingList.Controllers
{
    public class CategoriesController : Controller
    {
        public IShoppingListRepository shoppingListRepository { get; set; }

        // GET: Categories
        public ActionResult Index()
        {
            IEnumerable<DataProvider.Models.Category> cats = shoppingListRepository.GetCategories();
            return View(ViewModelMapper.MapCategories(cats));
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryViewModel category = ViewModelMapper.MapCategory(
                shoppingListRepository.GetCategory(id));
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,Name,DisplayOrder")] CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                shoppingListRepository.AddCategory(ViewModelMapper.MapAddUpdateCategory(category));
                shoppingListRepository.Save();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Category category = db.Categories.Find(id);
            CategoryViewModel category = ViewModelMapper.MapCategory(
                shoppingListRepository.GetCategory(id));
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,Name,DisplayOrder")] CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                shoppingListRepository.UpdateCategory(ViewModelMapper.MapAddUpdateCategory(category));
                shoppingListRepository.Save();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryViewModel category = ViewModelMapper.MapCategory(shoppingListRepository.GetCategory(id));
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            shoppingListRepository.DeleteCategory(id);
            shoppingListRepository.Save();
            return RedirectToAction("Index");
        }

    }
}
