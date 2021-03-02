using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Entities
{
    //Класс представляющий блюдо
    public class Dish : EntityBase
    {
        /// <summary>
        /// Название блюда.
        /// </summary>
        [Required(ErrorMessage = "Заполните название блюда")]
        [Display(Name = "Название блюда")]
        public override string Title { get; set; }

        /// <summary>
        /// Состав блюда.
        /// </summary>
        [Display(Name = "Состав блюда")]
        public override string Subtitle { get; set; }

        /// <summary>
        /// Описание блюда.
        /// </summary>
        [Display(Name = "Описание блюда")]
        public override string Text { get; set; }

        /// <summary>
        /// Фото блюда.
        /// </summary>
        [Display(Name = "Фото блюда")]
        public  string TitleImagePath { get; set; }

        /// <summary>
        /// Id категории блюд имеющей данное блюдо.
        /// </summary>
        [Required]
        public Guid DishesСategoryId { get; set; }

        /// <summary>
        /// Категория блюд имеющяя данное блюдо.
        /// </summary>
        public DishesСategory DishesСategory { get; set; }
    }
}
