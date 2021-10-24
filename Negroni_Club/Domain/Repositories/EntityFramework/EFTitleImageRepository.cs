using Microsoft.EntityFrameworkCore;
using Negroni_Club.Domain.Entities;
using Negroni_Club.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Repositories.EntityFramework
{
    public class EFTitleImageRepository : ITitleImageRepository
    {
        private readonly AppDbContext context;

        public EFTitleImageRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void SaveTitleImage(TitleImage entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteTitleImage(Guid id)
        {
            context.TitleImages.Remove(new TitleImage() { Id = id });
            context.SaveChanges();
        }

        public IEnumerable<TitleImage> GetTitleImages()
        {
            return context.TitleImages.ToList();
        }

        public TitleImage GetTitleImageByCodeWord(string codeWord)
        {
            return context.TitleImages.FirstOrDefault(x => x.CodeWord == codeWord);
        }
    }
}
