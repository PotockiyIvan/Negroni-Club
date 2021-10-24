using Negroni_Club.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Repositories.Abstract
{
   public interface IDishesCategoryRepository
    {

        IQueryable<DishesСategory> GetDishesCategories();

        DishesСategory GetDishesCategoryById(Guid id);

        public DishesСategory GetDishesCategoryByIndexNumber(int indexNumber);


        void SaveDishesCategory(DishesСategory entity);

        public void SaveDishesCategories(IQueryable<DishesСategory> entities);

        void DeleteDishesCategory(Guid id);
    }
}
