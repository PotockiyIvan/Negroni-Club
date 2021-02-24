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
        /// <summary>
        /// Ключевое слово.
        /// </summary>
        [Required]
        public string CodeWord { get; set; }//Ключевое слово,по нему будем обращаться к текстовому полю,чтобы не использовать id

        /// <summary>
        /// Заголовок.
        /// </summary>
        [Display(Name = "Название страницы (заголовок)")]
        public override string Title { get; set; } = "Информационная страница";

        /// <summary>
        /// Содержание страницы.
        /// </summary>
        [Display(Name = "Cодержание страницы")]
        public override string Text { get; set; } = "Содержание заполняется администратором";

        /// <summary>
        /// Титульные картинки.
        /// </summary>
        [Display(Name = "Титульные картинки")]
        public  List<TitleImage> TitleImages { get; set; }
    }
}
