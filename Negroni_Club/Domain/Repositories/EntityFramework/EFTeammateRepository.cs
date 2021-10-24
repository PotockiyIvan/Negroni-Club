using Microsoft.EntityFrameworkCore;
using Negroni_Club.Domain.Entities;
using Negroni_Club.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Repositories.EntityFramework
{
    public class EFTeammateRepository : ITeammateRepository
    {
        private readonly AppDbContext context;

        public EFTeammateRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void DeleteTeammate(Guid id)
        {
            //context.Teammates.Remove(new Teammate() { Id = id });
            context.Teammates.Remove(GetTeammateById(id));
            context.SaveChanges();
        }

        public Teammate GetTeammateById(Guid id)
        {
            return context.Teammates.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Teammate> GetTeammates()
        {
            return context.Teammates;
        }

        public void SaveTeammate(Teammate entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }


    }
}
