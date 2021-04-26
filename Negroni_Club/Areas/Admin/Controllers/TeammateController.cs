using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negroni_Club.Domain.Entities;
using Negroni_Club.Domain.Repositories;
using Negroni_Club.Service;

namespace Negroni_Club.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeammateController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;//Сохраняет титульные картинки
        public TeammateController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult EditOurTeam()
        {
            //var entity = dataManager.TextFields.GetTextFieldByCodeWord(codeword);
            //return View(entity);
            return View(dataManager.Teammates.GetTeammates());
        }


        public IActionResult EditTeammate(Guid id)
        {
            var entity = id == default ? new Teammate() : dataManager.Teammates.GetTeammateById(id);//тернарный оператор
            return View(entity);
            //return View(dataManager.Teammates.GetTeammates());
        }

        [HttpPost]
        public IActionResult EditTeammate(Teammate model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                    {
                        if(model.TitleImagePath != null)
                        {
                            if (System.IO.File.Exists(Path.Combine(hostingEnvironment.WebRootPath, "images/", model.TitleImagePath)))//System.ArgumentNullException: "Value cannot be null. "
                                System.IO.File.Delete(Path.Combine(hostingEnvironment.WebRootPath, "images/", model.TitleImagePath));
                        }

                        model.TitleImagePath = titleImageFile.FileName;
                        titleImageFile.CopyTo(stream);
                    }
                }
                dataManager.Teammates.SaveTeammate(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            System.IO.File.Delete(Path.Combine(hostingEnvironment.WebRootPath, "images/", dataManager.Teammates.GetTeammateById(id).TitleImagePath));
            dataManager.Teammates.DeleteTeammate(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
