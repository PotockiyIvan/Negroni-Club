using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Entities
{
    public class DishesСategory : EntityBase
    {
        public int IndexNumber { get; set; }

        [Display(Name = "Название категории")]
        public override string Title { get; set; }

        [Display(Name = "Блюда категории")]
        public List<Dish> Dishes { get; set; }

        [Display(Name = "Иконка")]
        public string TitleIconPath { get; set; }
    }
}
