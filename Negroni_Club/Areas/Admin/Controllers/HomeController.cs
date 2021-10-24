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
        private readonly IWebHostEnvironment hostingEnvironment;

        public HomeController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
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

        [HttpPost]
        public IActionResult EditAboutUs(TextField model, IFormFile bigTitleImage, IFormFile smallTitleImage)//Интерфейс представляет собой файл отправленный через http запрос
        {
            if (ModelState.IsValid)
            {
                model.TitleImages = dataManager.TitleImages.GetTitleImages().ToList().FindAll(x => x.CodeWord == "AboutUsBigTitleImage" || x.CodeWord == "AboutUsSmallTitleImage");

                if (bigTitleImage != null)
                    SaveTitleImage("AboutUsBigTitleImage", bigTitleImage, model);

                if (smallTitleImage != null)
                    SaveTitleImage("AboutUsSmallTitleImage", smallTitleImage, model);


                dataManager.TextFields.SaveTextField(model);

                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }
        #endregion

        #region EditEvents
        public IActionResult EditEvents(string codeWord)
        {
            var entity = dataManager.TextFields.GetTextFieldByCodeWord(codeWord);
            return View(entity);
        }

        [HttpPost]
        public IActionResult EditEvents(TextField model, IFormFile bigTitleImage, IFormFile smallTitleImage)
        {
            if (ModelState.IsValid)
            {
                model.TitleImages = dataManager.TitleImages.GetTitleImages().ToList().FindAll(x => x.CodeWord == "EventsBigTitleImage" || x.CodeWord == "EventsSmallTitleImage");

                if (bigTitleImage != null)
                    SaveTitleImage("EventsBigTitleImage", bigTitleImage, model);

                if (smallTitleImage != null)
                    SaveTitleImage("EventsSmallTitleImage", smallTitleImage, model);


                dataManager.TextFields.SaveTextField(model);

                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }
        #endregion

        private void SaveTitleImage(string codeWord, IFormFile titleImage, TextField model)
        {
            if (codeWord == "AboutUsBigTitleImage" || codeWord == "AboutUsSmallTitleImage")
            {
                using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", titleImage.FileName), FileMode.Create))
                {
                    System.IO.File.Delete(Path.Combine(hostingEnvironment.WebRootPath, "images/", model.TitleImages.FirstOrDefault(x => x.CodeWord == codeWord).TitleImagePath));
                    model.TitleImages.FindAll(x => x.CodeWord == codeWord).ForEach(s => s.TitleImagePath = titleImage.FileName);
                    titleImage.CopyTo(stream);
                }
            }
            else if (codeWord == "EventsBigTitleImage" || codeWord == "EventsSmallTitleImage")
            {
                using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/events", titleImage.FileName), FileMode.Create))
                {
                    var titleImage2 = new TitleImage { TitleImagePath = titleImage.FileName, TextFieldId = model.Id, CodeWord = codeWord };
                    dataManager.TitleImages.SaveTitleImage(titleImage2);
                    titleImage.CopyTo(stream);
                }
            }
        }
    }
}
