using Negroni_Club.Domain.Entities;
using Negroni_Club.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Negroni_Club.Domain.Repositories.EntityFramework
{
    public class EFDishRepository : IDishRepository
    {
        private readonly AppDbContext context;

        public EFDishRepository(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Удалить блюдо.
        /// </summary>
        /// <param name="id">Первичный ключ.</param>
        public void DeleteDish(Guid id)
        {
            context.Dishes.Remove(new Dish() { Id = id });
            context.SaveChanges();
        }

        /// <summary>
        /// Выбрать все блюда.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Dish> GetDishes()
        {
            return context.Dishes;
        }

        /// <summary>
        /// Выбрать блюдо по первичному ключу.
        /// </summary>
        /// <param name="id">Первичный ключ.</param>
        /// <returns></returns>
        public Dish GetDishById(Guid id)
        {
            return context.Dishes.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Сохранить блюдо.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        public void SaveDish(Dish entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
