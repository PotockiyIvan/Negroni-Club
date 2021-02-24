using Negroni_Club.Domain.Entities;
using Negroni_Club.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Domain.Repositories
{
    /*Класс помошник,который будет точкой входа для DataBase контекста
     * нужен для удобства управления сущностями из репозитория и всеми операциями над ними
     * вместо того ,чтобы по отдельности вызывать репозитории,можно будет передавать 
     * экземпляр этого класса и у него вызывать нужные свойства
    */
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IDishRepository Dishes { get; set; }
        public IDishesCategoryRepository DishesCategories {get;set;}
        public ITitleImageRepository TitleImages { get; set; }
        public ITeammateRepository Teammates { get; set; }


        public DataManager(ITextFieldsRepository textFieldsRepository,
                           IDishRepository dishRepository,
                           IDishesCategoryRepository dishesCategoryRepository,
                           ITitleImageRepository titleImageRepository,
                           ITeammateRepository teammateRepository)
        {
            TextFields = textFieldsRepository;
            Dishes = dishRepository;
            DishesCategories = dishesCategoryRepository;
            TitleImages = titleImageRepository;
            Teammates = teammateRepository;
        }
    }
}
