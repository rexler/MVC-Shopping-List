using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShoppingList.DataProvider.Models
{
    public class Meal
    {
        public virtual int MealId { get; set; }
        public virtual string Name { get; set; }
        [Display(Name = "Meal Items")]
        public virtual List<Item> Items { get; set; }
    }
}
