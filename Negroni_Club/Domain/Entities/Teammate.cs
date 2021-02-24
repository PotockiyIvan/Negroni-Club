using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Entities
{
    public class Teammate : EntityBase
    {

        /// <summary>
        /// Имя.
        /// </summary>
        [Display(Name = "Имя")]
        public override string Title { get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        [Display(Name = "Должность")]
        public override string Subtitle { get; set; }

        /// <summary>
        /// О себе.
        /// </summary>
        [Display(Name = "О себе")]
        public override string Text { get; set; }

        /// <summary>
        /// Титульная картинка.
        /// </summary>
        [Display(Name = "Титульная картинка")]
        public string TitleImagePath { get; set; }

        /// <summary>
        /// Ссылка на страницу Vk.
        /// </summary>
        [Display(Name ="Ссылка на страницу Vk")]
        public string VKLink { get; set; }

        /// <summary>
        /// Ссылка на страницу Instagram.
        /// </summary>
        [Display(Name = "Ссылка на страницу Instagram")]
        public string InstagramLink { get; set; }

        /// <summary>
        /// Ссылка на страницу Facebook.
        /// </summary>
        [Display(Name = "Ссылка на страницу Facebook")]
        public string FacebookLink { get; set; }
    }
}
