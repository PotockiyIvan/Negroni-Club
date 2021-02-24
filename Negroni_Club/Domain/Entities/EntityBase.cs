using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Entities
{
    /*Папка Domain содержит в себе доменные объекты(классы) которые будут проецироваться на
     * соотвествующие таблицы в базе данных,например есть класс - услуги и есть база данных с услугами
     * Папка Entities содержит все сущности
     EntityBase - базовый класс для всех таких сушностей*/
    public abstract class EntityBase
    {
        //Конструктор - при создании экземпляра будет давать текушее время полю DateAdded
        protected EntityBase() => DateAdded = DateTime.UtcNow;

        /// <summary>
        /// Первичный ключ.
        /// </summary>
        [Required]//- обязательно,т.к. это первичный ключ,без него не будет связи с базой данных
        public Guid Id { get; set; }

        /// <summary>
        /// Заголовок.
        /// </summary>
        [Display(Name = "Название")]
        public virtual string Title { get; set; }//Помечены как виртуал,чтобы можно было менять в дочерних по желанию

        /// <summary>
        /// Краткое описание.
        /// </summary>
        [Display(Name = "Краткое описание")]
        public virtual string Subtitle { get; set; }

        /// <summary>
        /// Полное описание.
        /// </summary>
        [Display(Name = "Полное описание")]
        public virtual string Text { get; set; }

        /// <summary>
        /// Дата добавления.
        /// </summary>
        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }

    }
}
