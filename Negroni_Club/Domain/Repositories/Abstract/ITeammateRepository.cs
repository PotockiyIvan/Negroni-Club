using Negroni_Club.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Repositories.Abstract
{
    public interface ITeammateRepository
    {
        /// <summary>
        /// Сделать выборку всех членов команды.
        /// </summary>
        /// <returns></returns>
        IQueryable<Teammate> GetTeammates();

        /// <summary>
        /// Выбрать члена команды по id.
        /// </summary>
        /// <param name="id">Первичный ключ.</param>
        /// <returns></returns>
        Teammate GetTeammateById(Guid id);

        /// <summary>
        /// Сохранить члена команды.
        /// </summary>
        /// <param name="entity"></param>
        void SaveTeammate(Teammate entity);

        /// <summary>
        /// Удалить члена команды.
        /// </summary>
        /// <param name="id">Первичный ключ.</param>
        void DeleteTeammate(Guid id);
    }
}
