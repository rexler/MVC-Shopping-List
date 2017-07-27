using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShoppingList.DataProvider.Models
{
    public class Item
    {
        public virtual int ItemId { get; set; }
        [Display(Name = "Item Name")]
        public virtual string Name { get; set; }
        public virtual int ItemOrder { get; set; }
        [Display(Name = "Category")]
        public virtual int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [Display(Name = "Meal Items")]
        public virtual List<Meal> Meals { get; set; }
        public virtual List<ShoppingList> ShoppingLists { get; set; }
    }
}
