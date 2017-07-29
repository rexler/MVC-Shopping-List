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
    public class MealsController : Controller
    {
        public IShoppingListRepository shoppingListRepository { get; set; }

        // GET: Meals
        public ActionResult Index()
        {
            IEnumerable<DataProvider.Models.Meal> meals = shoppingListRepository.GetMeals();

            return View(ViewModelMapper.MapMeals(meals));
        }

        // GET: Meals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealViewModel meal = ViewModelMapper.MapMeal(
                shoppingListRepository.GetMeal(id));

            IEnumerable<SelectListItem> mealItems = meal.Items.Select(m => new SelectListItem
            {
                Value = m.ItemId.ToString(),
                Text = m.Name
            });
            ViewBag.MealItems = mealItems; //meal.Items;
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // GET: Meals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MealId,Name")] MealViewModel meal)
        {
            if (ModelState.IsValid)
            {
                shoppingListRepository.AddMeal(ViewModelMapper.MapAddUpdateMeal(meal));
                shoppingListRepository.Save();
                return RedirectToAction("Index");
            }

            return View(meal);
        }

        // GET: Meals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealViewModel meal = ViewModelMapper.MapMeal(
                shoppingListRepository.GetMeal(id));
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // POST: Meals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MealId,Name")] MealViewModel meal)
        {
            if (ModelState.IsValid)
            {
                shoppingListRepository.UpdateMeal(ViewModelMapper.MapAddUpdateMeal(meal));
                shoppingListRepository.Save();
                return RedirectToAction("Index");
            }
            return View(meal);
        }

        // GET: Meals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MealViewModel meal = ViewModelMapper.MapMeal(shoppingListRepository.GetMeal(id));
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // POST: Meals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            shoppingListRepository.DeleteMeal(id);
            shoppingListRepository.Save();
            return RedirectToAction("Index");
        }

    }
}
