using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negroni_Club.Domain.Entities;
using Negroni_Club.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negroni_Club.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GalleryController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;//Сохраняет титульные картинки
        public GalleryController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            ViewBag.DataManager = dataManager;
            return View(ViewBag.DataManager);
        }

        public IActionResult EditAlbum(Guid id)
        {
            GalleryAlbum entity = dataManager.GalleryAlbums.GetGalleryAlbumById(id);

            return View(entity);
        }

        [HttpPost]
        public IActionResult EditAlbum(GalleryAlbum entity, IFormFile titleImageFile,List<IFormFile> photos)
        {
            return View();
        }
    }
}
