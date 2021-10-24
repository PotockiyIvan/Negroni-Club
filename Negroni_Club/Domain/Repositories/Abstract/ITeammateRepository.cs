using Negroni_Club.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Repositories.Abstract
{
    public interface ITeammateRepository
    {
        IQueryable<Teammate> GetTeammates();

        Teammate GetTeammateById(Guid id);

        void SaveTeammate(Teammate entity);

        void DeleteTeammate(Guid id);
    }
}
