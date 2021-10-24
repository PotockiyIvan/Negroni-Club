using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Entities
{
    public class Teammate : EntityBase
    {

        [Display(Name = "Имя")]
        public override string Title { get; set; }

        [Display(Name = "Должность")]
        public override string Subtitle { get; set; }

        [Display(Name = "О себе")]
        public override string Text { get; set; }

        [Display(Name = "Титульная картинка")]
        public string TitleImagePath { get; set; }

        [Display(Name ="Ссылка на страницу Vk")]
        public string VKLink { get; set; }

        [Display(Name = "Ссылка на страницу Instagram")]
        public string InstagramLink { get; set; }

        [Display(Name = "Ссылка на страницу Facebook")]
        public string FacebookLink { get; set; }
    }
}
