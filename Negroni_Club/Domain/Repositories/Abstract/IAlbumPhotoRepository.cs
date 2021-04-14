using Negroni_Club.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Repositories.Abstract
{
    public interface IAlbumPhotoRepository
    {
        /// <summary>
        /// Сделать выборку всех фото.
        /// </summary>
        /// <returns></returns>
        IQueryable<AlbumPhoto> GetAlbumPhotos();

        /// <summary>
        /// Выбрать фото по id.
        /// </summary>
        /// <param name="id">Первичный ключ.</param>
        /// <returns></returns>
        AlbumPhoto GetAlbumPhotoById(Guid id);

        /// <summary>
        /// Сохранить фото.
        /// </summary>
        /// <param name="entity"></param>
        void SaveAlbumPhoto(AlbumPhoto entity);

        /// <summary>
        /// Удалить фото.
        /// </summary>
        /// <param name="id">Первичный ключ.</param>
        void DeleteAlbumPhoto(Guid id);
    }
}
