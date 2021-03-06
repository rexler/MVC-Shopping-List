﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleShoppingList.Models
{
    public class MealViewModel
    {
        public virtual int MealId { get; set; }
        public virtual string Name { get; set; }
        [Display(Name = "Meal Items")]
        public virtual List<ItemViewModel> Items { get; set; }
    }
}