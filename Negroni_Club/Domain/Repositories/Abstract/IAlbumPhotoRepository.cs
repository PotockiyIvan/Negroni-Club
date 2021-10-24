using Negroni_Club.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Repositories.Abstract
{
    public interface IAlbumPhotoRepository
    {
        IQueryable<AlbumPhoto> GetAlbumPhotos();

        AlbumPhoto GetAlbumPhotoById(Guid id);

        void SaveAlbumPhoto(AlbumPhoto entity);

        void DeleteAlbumPhoto(Guid id);

    }
}
