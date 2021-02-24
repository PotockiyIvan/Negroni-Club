using Negroni_Club.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Repositories.Abstract
{
    /*Этот интерфейс определяет базовую логику поведения дрменного объекта TextField
     *Для того,чтобы администратор мог производить манипуляции с объектами в своей панели*/
    public interface ITextFieldsRepository
    {
        /// <summary>
        /// Сделать выборку всех текстовых полей.
        /// </summary>
        /// <returns></returns>
        IQueryable<TextField> GetTextFields();

        /// <summary>
        /// Выбрать текстовое поле по id.
        /// </summary>
        /// <param name="id">Первичный ключ.</param>
        /// <returns></returns>
        TextField GetTextFieldById(Guid id);

        /// <summary>
        /// Выбрать текстовое поле по кодовому слову.
        /// </summary>
        /// <param name="codeWord">Кодовое слово.</param>
        /// <returns></returns>
        TextField GetTextFieldByCodeWord(string codeWord);

        /// <summary>
        /// Сохранить текстовое поле.
        /// </summary>
        /// <param name="entity"></param>
        void SaveTextField(TextField entity);

        /// <summary>
        /// Удалить текстовое поле.
        /// </summary>
        /// <param name="id">Первичный ключ.</param>
        void DeleteTextField(Guid id);
    }
}
