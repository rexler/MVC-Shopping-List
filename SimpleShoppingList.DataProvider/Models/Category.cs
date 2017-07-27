using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShoppingList.DataProvider.Models
{
    public class Category
    {
        public virtual int CategoryId { get; set; }
        [Display(Name = "Category Name")]
        public virtual string Name { get; set; }
        public virtual int DisplayOrder { get; set; }
    }
}
