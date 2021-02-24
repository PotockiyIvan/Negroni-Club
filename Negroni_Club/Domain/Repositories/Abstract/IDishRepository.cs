using Negroni_Club.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Repositories.Abstract
{
    /*Этот интерфейс определяет базовую логику поведения дрменного объекта Dish
     *Для того,чтобы администратор мог производить манипуляции с объектами в своей панели*/
    public interface IDishRepository
    {
        /// <summary>
        /// Сделать выборку всех блюд.
        /// </summary>
        /// <returns></returns>
        IQueryable<Dish> GetDishes();

        /// <summary>
        /// Выбрать блюдо по id.
        /// </summary>
        /// <param name="id">Первичный ключ.</param>
        /// <returns></returns>
        Dish GetDishById(Guid id);

        /// <summary>
        /// Сохранить блюдо.
        /// </summary>
        /// <param name="entity"></param>
        void SaveDish(Dish entity);

        /// <summary>
        /// Удалить блюдо.
        /// </summary>
        /// <param name="id">Первичный ключ.</param>
        void DeleteDish(Guid id);
    }
}
