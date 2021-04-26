using Microsoft.EntityFrameworkCore;
using Negroni_Club.Domain.Entities;
using Negroni_Club.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Repositories.EntityFramework
{
    public class EFGalleryAlbumRepository : IGalleryAlbumRepository
    {
        private readonly AppDbContext context;

        public EFGalleryAlbumRepository(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Удалить альбом.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteGalleryAlbum(Guid id)
        {
            context.GalleryAlbums.Remove(GetGalleryAlbumById(id));
            context.SaveChanges();
        }

        /// <summary>
        /// Выбрать альбом по id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GalleryAlbum GetGalleryAlbumById(Guid id)
        {
            return context.GalleryAlbums.Include(x => x.AlbumPhotos).FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Сделать выборку всех альбомов.
        /// </summary>
        /// <returns></returns>
        public IQueryable<GalleryAlbum> GetGalleryAlbums()
        {
            return context.GalleryAlbums.Include(x => x.AlbumPhotos);
        }

        /// <summary>
        /// Сохранить альбом.
        /// </summary>
        /// <param name="entity"></param>
        public void SaveGalleryAlbum(GalleryAlbum entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        /// <summary>
        /// Получить случайное фото.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AlbumPhoto GetRandomPhoto(Guid id)
        {
            GalleryAlbum album = GetGalleryAlbumById(id);
            var albumPhotos = album.AlbumPhotos;
            var random = new Random();
            int index = random.Next(albumPhotos.Count());
            AlbumPhoto albumPhoto = albumPhotos.ElementAt(index);

            return albumPhoto;
        }
    }
}
