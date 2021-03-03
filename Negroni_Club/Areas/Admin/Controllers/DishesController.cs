using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Negroni_Club.Domain;
using Negroni_Club.Domain.Entities;
using Negroni_Club.Domain.Repositories.Abstract;
using Negroni_Club.Domain.Repositories;
using Negroni_Club.Service;

namespace Negroni_Club.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DishesController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;//Сохраняет титульные картинки
        public DishesController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            ViewBag.DataManager = dataManager;
            return View(ViewBag.DataManager);
        }

        #region Edit Dishes

        public IActionResult DishList(Guid id)
        {
            var model =  dataManager.DishesCategories.GetDishesCategoryById(id);
            return View(model);
        }

        /*В этот метод будет приходить id либо блюда лиюбо категории блюд,в зависимости
          от того, что нужно сделать - создать или редактировать.*/
        public IActionResult EditDish(Guid id)
        {
            Dish entity = new Dish();
            var category = dataManager.DishesCategories.GetDishesCategoryById(id);

            if (category != null)
                entity.DishesСategoryId = category.Id;
            else
               entity = dataManager.Dishes.GetDishById(id);

            return View(entity);
        }
        [HttpPost]
        public IActionResult EditDish(Dish model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    model.TitleImagePath = titleImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/dish images", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }
                dataManager.Dishes.SaveDish(model);
                return View("DishList", dataManager.DishesCategories.GetDishesCategoryById(model.DishesСategoryId));
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            var category = dataManager.DishesCategories.GetDishesCategoryById(dataManager.Dishes.GetDishById(id).DishesСategoryId);

            System.IO.File.Delete(Path.Combine(hostingEnvironment.WebRootPath, "images/dish Images/", dataManager.Dishes.GetDishById(id).TitleImagePath));
            dataManager.Dishes.DeleteDish(id);

            return View("DishList",category);
        }

        #endregion

        #region Edit DishesCategories

        public IActionResult EditDishCategory(Guid id)
        {
            var entity = id == default ? new DishesСategory() : dataManager.DishesCategories.GetDishesCategoryById(id);
            return View(entity);
        }

        /// <summary>
        /// Изменить\Добавить категорию блюд.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditDishCategory(DishesСategory model, string titleIconName)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == default)
                {
                    var category = dataManager.DishesCategories.GetDishesCategories().OrderBy(x => x.IndexNumber).Last();
                    model.IndexNumber = category.IndexNumber + 1;
                    model.TitleIconPath = titleIconName;
                }
                if (titleIconName != null)
                    model.TitleIconPath = titleIconName;
                dataManager.DishesCategories.SaveDishesCategory(model);
            }
            return RedirectToAction(nameof(DishesController.Index), nameof(DishesController).CutController());
        }

        /// <summary>
        /// Удалить категорию блюд.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteDishCategory(Guid id)
        {
            var categories = dataManager.DishesCategories.GetDishesCategories();
            var currenCategory = dataManager.DishesCategories.GetDishesCategoryById(id);

            foreach (var category in categories)
            {
                if (category.IndexNumber > currenCategory.IndexNumber)
                    --category.IndexNumber;
            }
            dataManager.DishesCategories.SaveDishesCategories(categories);
            dataManager.DishesCategories.DeleteDishesCategory(id);
            return RedirectToAction(nameof(DishesController.Index), nameof(DishesController).CutController());
        }

        /// <summary>
        /// Поднять категорию вверх на одну позицию.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Up(Guid id)
        {
            DishesСategory currenCategory = dataManager.DishesCategories.GetDishesCategoryById(id);
            DishesСategory previousСategory;

            if (currenCategory.IndexNumber - 1 == 0)
            {
                previousСategory = dataManager.DishesCategories.GetDishesCategories().OrderBy(x => x.IndexNumber).Last();
                currenCategory.IndexNumber = previousСategory.IndexNumber;
                previousСategory.IndexNumber = 1;
            }
            else
            {
                previousСategory = dataManager.DishesCategories.GetDishesCategoryByIndexNumber(currenCategory.IndexNumber - 1);
                ++previousСategory.IndexNumber;
                --currenCategory.IndexNumber;
            }

            dataManager.DishesCategories.SaveDishesCategory(currenCategory);
            dataManager.DishesCategories.SaveDishesCategory(previousСategory);

            return RedirectToAction(nameof(DishesController.Index), nameof(DishesController).CutController());
        }

        /// <summary>
        /// Опустить категорию вниз на одну позицию.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Down(Guid id)
        {
            DishesСategory currenCategory = dataManager.DishesCategories.GetDishesCategoryById(id);
            DishesСategory nextСategory;

            if (currenCategory == dataManager.DishesCategories.GetDishesCategories().OrderBy(x => x.IndexNumber).Last())
            {
                nextСategory = dataManager.DishesCategories.GetDishesCategoryByIndexNumber(1);
                nextСategory.IndexNumber = currenCategory.IndexNumber;
                currenCategory.IndexNumber = 1;
            }
            else
            {
                nextСategory = dataManager.DishesCategories.GetDishesCategoryByIndexNumber(currenCategory.IndexNumber + 1);
                --nextСategory.IndexNumber;
                ++currenCategory.IndexNumber;
            }

            dataManager.DishesCategories.SaveDishesCategory(currenCategory);
            dataManager.DishesCategories.SaveDishesCategory(nextСategory);

            return RedirectToAction(nameof(DishesController.Index), nameof(DishesController).CutController());
        }

        #endregion
    }
}
