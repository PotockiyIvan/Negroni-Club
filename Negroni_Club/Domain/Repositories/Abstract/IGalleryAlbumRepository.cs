using Negroni_Club.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Repositories.Abstract
{
    public interface IGalleryAlbumRepository
    {
        /// <summary>
        /// Сделать выборку всех альбомов.
        /// </summary>
        /// <returns></returns>
        IQueryable<GalleryAlbum> GetGalleryAlbums();

        /// <summary>
        /// Выбрать альбом по id.
        /// </summary>
        /// <param name="id">Первичный ключ.</param>
        /// <returns></returns>
        GalleryAlbum GetGalleryAlbumById(Guid id);

        /// <summary>
        /// Сохранить альбом.
        /// </summary>
        /// <param name="entity"></param>
        void SaveGalleryAlbum(GalleryAlbum entity);

        /// <summary>
        /// Удалить альбом.
        /// </summary>
        /// <param name="id">Первичный ключ.</param>
        void DeleteGalleryAlbum(Guid id);

        /// <summary>
        /// Получить случайное фото.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AlbumPhoto GetRandomPhoto(Guid id);
    }
}
