using Microsoft.EntityFrameworkCore;
using Negroni_Club.Domain.Entities;
using Negroni_Club.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Repositories.EntityFramework
{
    public class EFDishesCategoryRepository : IDishesCategoryRepository
    {
        private readonly AppDbContext context;

        public EFDishesCategoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void DeleteDishesCategory(Guid id)
        {
            context.DishesCategories.Remove(GetDishesCategoryById(id));
            context.SaveChanges();
        }

        public IQueryable<DishesСategory> GetDishesCategories()
        {
            return context.DishesCategories.Include(x => x.Dishes);
        }

        public DishesСategory GetDishesCategoryById(Guid id)
        {
            return context.DishesCategories.Include(x => x.Dishes).FirstOrDefault(x => x.Id == id);
        }

        public DishesСategory GetDishesCategoryByIndexNumber(int indexNumber)
        {
            return context.DishesCategories.FirstOrDefault(x => x.IndexNumber == indexNumber);
        }

        public void SaveDishesCategory(DishesСategory entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;

            context.SaveChanges();
        }

        public void SaveDishesCategories(IQueryable<DishesСategory> entities)
        {
            foreach (DishesСategory сategory in entities)
            {
                if (сategory.Id == default)
                    context.Entry(сategory).State = EntityState.Added;
                else
                    context.Entry(сategory).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
