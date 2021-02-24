using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Negroni_Club.Domain.Entities;
using Negroni_Club.Domain.Repositories.Abstract;
namespace Negroni_Club.Domain.Repositories.EntityFramework
{
    public class EFTextFieldsRepository : ITextFieldsRepository
    {
        private readonly AppDbContext context;

        public EFTextFieldsRepository(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Удалить текстовое поле.
        /// </summary>
        /// <param name="id">Первичный ключ.</param>
        public void DeleteTextField(Guid id)
        {
            //В целях сокращения кода мы не передаем сам объект а создаем фейковый и присваеваем ему нужный id
            context.TextFields.Remove(new TextField() { Id = id });
            context.SaveChanges();
        }

        /// <summary>
        /// Выбрать текстовое поле по кодовому слову.
        /// </summary>
        /// <param name="codeWord">Кодовое слово.</param>
        /// <returns></returns>
        public TextField GetTextFieldByCodeWord(string codeWord)
        {
            return context.TextFields.Include(x => x.TitleImages).FirstOrDefault(x => x.CodeWord == codeWord);
        }

        /// <summary>
        /// Выбрать текстовое поле по первичному ключу.
        /// </summary>
        /// <param name="id">Перыичный ключ.</param>
        /// <returns></returns>
        public TextField GetTextFieldById(Guid id)
        {
            return context.TextFields.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Выбрать все текстовые поля.
        /// </summary>
        /// <returns></returns>
        public IQueryable<TextField> GetTextFields()
        {
            return context.TextFields;
        }

        /// <summary>
        /// Сохранить текстовое поле.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        public void SaveTextField(TextField entity)
        {
            if (entity.Id == default)//== дефолт для guid
                context.Entry(entity).State = EntityState.Added;//EntityState - состояние сущности Added - новая
            else
                context.Entry(entity).State = EntityState.Modified;//Modified - измененная
            //В итоге либо добавим новый объект либо изменим существуюший
            context.SaveChanges();
        }
    }
}
