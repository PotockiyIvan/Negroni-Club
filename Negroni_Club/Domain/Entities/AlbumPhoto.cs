using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Entities
{
    public class AlbumPhoto : EntityBase
    {
        /// <summary>
        /// Id альбома имеюшего данное фото.
        /// </summary>
        [Required]
        public Guid GalleryAlbumId { get; set; }

        /// <summary>
        /// Альбом имеющий данное фото.
        /// </summary>
        [Required]
        public GalleryAlbum GalleryAlbum { get; set; }

        /// <summary>
        /// Фото альбома.
        /// </summary>
        [Display(Name = "Фото альбома")]
        public string AlbumPhotoPath { get; set; }
    }
}
