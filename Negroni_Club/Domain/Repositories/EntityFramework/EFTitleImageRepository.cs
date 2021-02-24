using Microsoft.EntityFrameworkCore;
using Negroni_Club.Domain.Entities;
using Negroni_Club.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Repositories.EntityFramework
{
    public class EFTitleImageRepository : ITitleImageRepository
    {
        private readonly AppDbContext context;

        public EFTitleImageRepository(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Сохранить титульную картинку.
        /// </summary>
        /// <param name="entity"></param>
        public void SaveTitleImage(TitleImage entity)
        {
            if (entity.Id == default)//== дефолт для guid
                context.Entry(entity).State = EntityState.Added;//EntityState - состояние сущности Added - новая
            else
                context.Entry(entity).State = EntityState.Modified;//Modified - измененная
            //В итоге либо добавим новый объект либо изменим существуюший
            context.SaveChanges();
        }

        /// <summary>
        /// Удалить титульную картинку.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteTitleImage(Guid id)
        {
            //В целях сокращения кода мы не передаем сам объект а создаем фейковый и присваеваем ему нужный id
            context.TitleImages.Remove(new TitleImage() { Id = id });
            context.SaveChanges();
        }


        /// <summary>
        /// Выбрать все титульные картинки.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TitleImage> GetTitleImages()
        {
            return context.TitleImages.ToList();
        }

        /// <summary>
        /// Выбрать титульную картику по кодовому слову.
        /// </summary>
        /// <param name="codeWord">Кодовое слово.</param>
        /// <returns></returns>
        public TitleImage GetTitleImageByCodeWord(string codeWord)
        {
            return context.TitleImages.FirstOrDefault(x => x.CodeWord == codeWord);
        }
    }
}
