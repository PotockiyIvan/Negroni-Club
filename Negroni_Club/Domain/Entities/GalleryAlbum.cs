using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Entities
{
    public class GalleryAlbum : EntityBase
    {
        [Display(Name = "Название мероприятия")]
        public override string Title { get; set; }

        [Display(Name ="Дата проведения мероприятия")]
        public DateTime EventDate { get; set; }

        [Display(Name = "Титульная картинка альбома")]
        public string TitleImagePath { get; set; }

        [Display(Name ="Фотографии альбома")]
        public List<AlbumPhoto> AlbumPhotos { get; set; } 
    }
}
