using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Entities
{
    public class TitleImage
    {
        public TitleImage() => DateAdded = DateTime.UtcNow;

        /// <summary>
        /// Ключевое слово.
        /// </summary>
        [Required]
        public string CodeWord { get; set; }//Ключевое слово,по нему будем обращаться к текстовому полю,чтобы не использовать id

        /// <summary>
        /// Первичный ключ.
        /// </summary>
        [Required]//- обязательно,т.к. это первичный ключ,без него не будет связи с базой данных
        public Guid Id { get; set; }

        /// <summary>
        /// Id текстового поля имеюшего данную титульную картинку.
        /// </summary>
        [Required]
        public Guid TextFieldId { get; set; }

        /// <summary>
        /// Текстовое поле имеющее данную титульную картинку.
        /// </summary>
        [Required]
        public TextField TextField { get; set; }

        /// <summary>
        /// Титульная картинка.
        /// </summary>
        [Display(Name = "Титульная картинка")]
        public  string TitleImagePath { get; set; }

        /// <summary>
        /// Дата добавления.
        /// </summary>
        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }
}
