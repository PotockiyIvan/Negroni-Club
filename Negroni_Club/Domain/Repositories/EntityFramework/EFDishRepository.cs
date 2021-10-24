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

        public void DeleteDish(Guid id)
        {
            context.Dishes.Remove(GetDishById(id));
            context.SaveChanges();
        }

        public IQueryable<Dish> GetDishes()
        {
            return context.Dishes;
        }

        public Dish GetDishById(Guid id)
        {
            return context.Dishes.FirstOrDefault(x => x.Id == id);
        }

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
