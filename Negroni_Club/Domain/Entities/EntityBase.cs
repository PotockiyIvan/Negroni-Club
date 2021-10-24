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
        protected EntityBase() => DateAdded = DateTime.UtcNow;

        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Название")]
        public virtual string Title { get; set; }

        [Display(Name = "Краткое описание")]
        public virtual string Subtitle { get; set; }

        [Display(Name = "Полное описание")]
        public virtual string Text { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }

    }
}
