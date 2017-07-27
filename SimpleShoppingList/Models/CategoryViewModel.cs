using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleShoppingList.Models
{
    public class CategoryViewModel
    {
        public virtual int CategoryId { get; set; }
        [Display(Name = "Category Name")]
        public virtual string Name { get; set; }
        public virtual int DisplayOrder { get; set; }
    }
}