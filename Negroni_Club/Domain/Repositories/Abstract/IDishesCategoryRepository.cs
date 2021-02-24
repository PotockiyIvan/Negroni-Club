using Negroni_Club.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Repositories.Abstract
{
   public interface IDishesCategoryRepository
    {

        /// <summary>
        /// Сделать выборку всех категорий блюд.
        /// </summary>
        /// <returns></returns>
        IQueryable<DishesСategory> GetDishesCategories();

        /// <summary>
        /// Выбрать категорию блюд по id.
        /// </summary>
        /// <param name="id">Первичный ключ.</param>
        /// <returns></returns>
        DishesСategory GetDishesCategoryById(Guid id);

        /// <summary>
        /// Получить категорию блюд по IndexNumber.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DishesСategory GetDishesCategoryByIndexNumber(int indexNumber);

        ///// <summary>
        ///// Выбрать категорию по кодовому слову.
        ///// </summary>
        ///// <param name="codeWord">Кодовое слово.</param>
        ///// <returns></returns>
        //TextField GetTextFieldByCodeWord(string codeWord);

        /// <summary>
        /// Сохранить категорию блюд.
        /// </summary>
        /// <param name="entity"></param>
        void SaveDishesCategory(DishesСategory entity);

        /// <summary>
        /// Сохранить список категорий.
        /// </summary>
        /// <param name="entities"></param>
        public void SaveDishesCategories(IQueryable<DishesСategory> entities);

        /// <summary>
        /// Удалить категорию блюд.
        /// </summary>
        /// <param name="id">Первичный ключ.</param>
        void DeleteDishesCategory(Guid id);
    }
}
