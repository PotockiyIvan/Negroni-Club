using Negroni_Club.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Repositories.Abstract
{
    public interface IGalleryAlbumRepository
    {
        IQueryable<GalleryAlbum> GetGalleryAlbums();

        GalleryAlbum GetGalleryAlbumById(Guid id);

        void SaveGalleryAlbum(GalleryAlbum entity);

        void DeleteGalleryAlbum(Guid id);

        public AlbumPhoto GetRandomPhoto(Guid id);
    }
}
