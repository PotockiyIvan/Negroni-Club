using Microsoft.EntityFrameworkCore;
using Negroni_Club.Domain.Entities;
using Negroni_Club.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Repositories.EntityFramework
{
    public class EFAlbumPhotoRepository : IAlbumPhotoRepository
    {
        private readonly AppDbContext context;

        public EFAlbumPhotoRepository(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Удалить фото.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteAlbumPhoto(Guid id)
        {
            context.AlbumPhotos.Remove(GetAlbumPhotoById(id));
            context.SaveChanges();
        }

        /// <summary>
        /// Выбрать фото по id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AlbumPhoto GetAlbumPhotoById(Guid id)
        {
            return context.AlbumPhotos.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Сделать выборку всех фото.
        /// </summary>
        /// <returns></returns>
        public IQueryable<AlbumPhoto> GetAlbumPhotos()
        {
            return context.AlbumPhotos;
        }

        /// <summary>
        /// Сохранить фото.
        /// </summary>
        /// <param name="entity"></param>
        public void SaveAlbumPhoto(AlbumPhoto entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
