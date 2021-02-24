using Microsoft.EntityFrameworkCore;
using Negroni_Club.Domain.Entities;
using Negroni_Club.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Repositories.EntityFramework
{
    public class EFTeammateRepository : ITeammateRepository
    {
        private readonly AppDbContext context;

        public EFTeammateRepository(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Удалить члена команды.
        /// </summary>
        /// <param name="id">Первичный ключ.</param>
        public void DeleteTeammate(Guid id)
        {
            //context.Teammates.Remove(new Teammate() { Id = id });
            context.Teammates.Remove(GetTeammateById(id));
            context.SaveChanges();
        }

        ///// <summary>
        ///// Выбрать члена команды по кодовому слову.
        ///// </summary>
        ///// <param name="codeWord">Кодовое слово.</param>
        ///// <returns></returns>
        //public Teammate GetTeammateByCodeWord(string codeWord)
        //{
        //    return context.Teammates.FirstOrDefault(x => x.CodeWord == codeWord);
        //}

        /// <summary>
        /// Выбрать члена команды по первичному ключу.
        /// </summary>
        /// <param name="id">Перыичный ключ.</param>
        /// <returns></returns>
        public Teammate GetTeammateById(Guid id)
        {
            return context.Teammates.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Выбрать всеx членов команды.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Teammate> GetTeammates()
        {
            return context.Teammates;
        }

        /// <summary>
        /// Сохранить члена команды.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        public void SaveTeammate(Teammate entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }


    }
}
