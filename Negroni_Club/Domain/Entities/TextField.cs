using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Entities
{
    //Класс представляющий текстовое поле
    public class TextField : EntityBase
    {
        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Название страницы (заголовок)")]
        public override string Title { get; set; } = "Информационная страница";

        [Display(Name = "Cодержание страницы")]
        public override string Text { get; set; } = "Содержание заполняется администратором";

        [Display(Name = "Титульные картинки")]
        public  List<TitleImage> TitleImages { get; set; }
    }
}
