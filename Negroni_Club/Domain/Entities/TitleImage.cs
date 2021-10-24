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

        [Required]
        public string CodeWord { get; set; }

        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid TextFieldId { get; set; }

        [Required]
        public TextField TextField { get; set; }

        [Display(Name = "Титульная картинка")]
        public  string TitleImagePath { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }
}
