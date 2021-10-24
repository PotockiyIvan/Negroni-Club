using Negroni_Club.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Repositories.Abstract
{
    public interface ITitleImageRepository
    {
        void SaveTitleImage(TitleImage entity);

        void DeleteTitleImage(Guid id);

        IEnumerable<TitleImage> GetTitleImages();
    }
}

