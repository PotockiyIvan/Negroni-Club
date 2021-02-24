using Negroni_Club.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Repositories.Abstract
{
    public interface ITitleImageRepository
    {
        /// <summary>
        /// Сохранить титульную картинку.
        /// </summary>
        /// <param name="entity"></param>
        void SaveTitleImage(TitleImage entity);

        /// <summary>
        /// Удалить Удалить титульную картинку.
        /// </summary>
        /// <param name="id">Первичный ключ.</param>
        void DeleteTitleImage(Guid id);

        /// <summary>
        /// Выбрать все титульные картинки.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TitleImage> GetTitleImages();
    }
}

