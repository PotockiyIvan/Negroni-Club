using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negroni_Club.Domain.Entities;
using Negroni_Club.Domain.Repositories;
using Negroni_Club.Service;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using Negroni_Club.Domain.Repositories.Abstract;

namespace Negroni_Club.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;//Хостинг окружение ,сохраняет титульные картинки

        public HomeController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View(dataManager.Dishes.GetDishes());
        }

        #region EditMenu
        [HttpPost]
        public IActionResult EditMenu(string title, string subTitle)
        {
            var model = dataManager.TextFields.GetTextFieldByCodeWord("Menu");

            model.Title = title;
            model.Subtitle = subTitle;

            dataManager.TextFields.SaveTextField(model);
            return RedirectToAction(nameof(DishesController.Index), nameof(DishesController).CutController());

        }
        #endregion

        #region EditBanner
        public IActionResult EditBanner(string codeWord)
        {
            var entity = dataManager.TextFields.GetTextFieldByCodeWord(codeWord);
            return View(entity);
        }

        [HttpPost]
        public IActionResult EditBanner(TextField model, IFormFile BannerBackground)
        {
            if (ModelState.IsValid)
            {
                if (BannerBackground != null)
                {
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", BannerBackground.FileName), FileMode.Create))
                    {
                        model.TitleImages = dataManager.TitleImages.GetTitleImages().ToList().FindAll(x => x.CodeWord == "BannerBackground");
                        System.IO.File.Delete(Path.Combine(hostingEnvironment.WebRootPath, "images/", model.TitleImages.FirstOrDefault(x => x.CodeWord == "BannerBackground").TitleImagePath));
                        model.TitleImages.FindAll(x => x.CodeWord == "BannerBackground").ForEach(s => s.TitleImagePath = BannerBackground.FileName);
                        BannerBackground.CopyTo(stream);//НЕПОНЯТНО!!!!!
                    }
                }

                dataManager.TextFields.SaveTextField(model);

                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }
        #endregion

        #region EditAboutUs
        public IActionResult EditAboutUs(string codeWord)
        {
            var entity = dataManager.TextFields.GetTextFieldByCodeWord(codeWord);
            return View(entity);
        }

        [HttpPost]//Получаем от html формы модель ,проверяем ее и сохраняем
        public IActionResult EditAboutUs(TextField model, IFormFile bigTitleImage, IFormFile smallTitleImage)//Интерфейс представляет собой файл отправленный через http запрос
        {
            /*В этом методе мы получаем модель и два файла - картинки,далее если они не равны нулю,
             *сохраняем эти картинки в wwwroot попутно удаляя старые именяем 
             *путь в свойстве модели в бд и в связанной с ней таблицей.
             *Подумай как в дальнейшем вынести эту логику в отдельный метод
            */

            if (ModelState.IsValid)
            {
                model.TitleImages = dataManager.TitleImages.GetTitleImages().ToList().FindAll(x => x.CodeWord == "AboutUsBigTitleImage" || x.CodeWord == "AboutUsSmallTitleImage");

                if (bigTitleImage != null)
                {
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", bigTitleImage.FileName), FileMode.Create))
                    {
                        System.IO.File.Delete(Path.Combine(hostingEnvironment.WebRootPath, "images/", model.TitleImages.FirstOrDefault(x => x.CodeWord == "AboutUsBigTitleImage").TitleImagePath));
                        model.TitleImages.FindAll(x => x.CodeWord == "AboutUsBigTitleImage").ForEach(s => s.TitleImagePath = bigTitleImage.FileName);
                        bigTitleImage.CopyTo(stream);//НЕПОНЯТНО!!!!!
                    }
                }

                if (smallTitleImage != null)
                {
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", smallTitleImage.FileName), FileMode.Create))
                    {
                        System.IO.File.Delete(Path.Combine(hostingEnvironment.WebRootPath, "images/", model.TitleImages.FirstOrDefault(x => x.CodeWord == "AboutUsSmallTitleImage").TitleImagePath));
                        model.TitleImages.FindAll(x => x.CodeWord == "AboutUsSmallTitleImage").ForEach(s => s.TitleImagePath = smallTitleImage.FileName);
                        smallTitleImage.CopyTo(stream);//НЕПОНЯТНО!!!!!
                    }
                }
                dataManager.TextFields.SaveTextField(model);

                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }
        #endregion

    }
}
