using Negroni_Club.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Repositories.Abstract
{
    /*Этот интерфейс определяет базовую логику поведения доменного объекта Dish
     *Для того,чтобы администратор мог производить манипуляции с объектами в своей панели*/
    public interface IDishRepository
    {
        IQueryable<Dish> GetDishes();

        Dish GetDishById(Guid id);

        void SaveDish(Dish entity);

        void DeleteDish(Guid id);
    }
}
