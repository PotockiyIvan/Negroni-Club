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

        public void DeleteTextField(Guid id)
        {
            //В целях сокращения кода мы не передаем сам объект а создаем фейковый и присваеваем ему нужный id
            context.TextFields.Remove(new TextField() { Id = id });
            context.SaveChanges();
        }

        public TextField GetTextFieldByCodeWord(string codeWord)
        {
            return context.TextFields.Include(x => x.TitleImages).FirstOrDefault(x => x.CodeWord == codeWord);
        }

        public TextField GetTextFieldById(Guid id)
        {
            return context.TextFields.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<TextField> GetTextFields()
        {
            return context.TextFields;
        }

        public void SaveTextField(TextField entity)
        {
            if (entity.Id == default)//== дефолт для guid
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
