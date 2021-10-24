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
        [Required(ErrorMessage = "Введите название блюда")]
        [Display(Name = "Название блюда")]
        public override string Title { get; set; }

        [Display(Name = "Состав блюда")]
        public override string Subtitle { get; set; }

        [Display(Name = "Описание блюда")]
        public override string Text { get; set; }

        [Display(Name ="Цена")]
        public int Price { get; set; }

        [Display(Name = "Фото блюда")]
        public  string TitleImagePath { get; set; }

        [Required]
        public Guid DishesСategoryId { get; set; }

        public DishesСategory DishesСategory { get; set; }
    }
}
