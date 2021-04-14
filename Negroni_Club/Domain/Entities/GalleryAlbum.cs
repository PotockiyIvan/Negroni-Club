using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Entities
{
    public class GalleryAlbum : EntityBase
    {
        /// <summary>
        /// Название мероприятия.
        /// </summary>
        [Display(Name = "Название мероприятия")]
        public override string Title { get; set; }

        /// <summary>
        /// Дата проведения мероприятия.
        /// </summary>
        [Display(Name ="Дата проведения мероприятия")]
        public DateTime EventDate { get; set; }

        /// <summary>
        /// Титульная картинка альбома.
        /// </summary>
        [Display(Name = "Титульная картинка альбома")]
        public string TitleImagePath { get; set; }

        /// <summary>
        /// Фотографии альбома.
        /// </summary>
        [Display(Name ="Фотографии альбома")]
        public List<AlbumPhoto> AlbumPhotos { get; set; } 
    }
}
