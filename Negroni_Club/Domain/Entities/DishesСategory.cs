using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Entities
{
    public class DishesСategory : EntityBase
    {
        /// <summary>
        /// Порядковый номер.
        /// </summary>
        public int IndexNumber { get; set; }

        /// <summary>
        /// Название подкатегории.
        /// </summary>
        [Display(Name = "Название категории")]
        public override string Title { get; set; }

        /// <summary>
        /// Блюда подкатегории.
        /// </summary>
        [Display(Name = "Блюда категории")]
        public List<Dish> Dishes { get; set; }

        /// <summary>
        /// Иконка категории.
        /// </summary>
        [Display(Name = "Иконка")]
        public string TitleIconPath { get; set; }
    }
}
