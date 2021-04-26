using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negroni_Club.Domain.Entities;
using Negroni_Club.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
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
            var entity = id == default ? new GalleryAlbum() : dataManager.GalleryAlbums.GetGalleryAlbumById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult EditAlbum(GalleryAlbum model,List<IFormFile> photos)
        {
            if (ModelState.IsValid)
            {
                if(photos != null)
                {
                    string albumFolderPath = hostingEnvironment.WebRootPath +"/images/gallery/album from " + model.EventDate.ToShortDateString();
                    Directory.CreateDirectory(albumFolderPath);

                    model.AlbumPhotos = new List<AlbumPhoto>();

                    foreach (IFormFile photo in photos)
                    {
                        AlbumPhoto albumPhoto = new AlbumPhoto { AlbumPhotoPath = photo.FileName };
                        model.AlbumPhotos.Add(albumPhoto);
                        
                        using (var stream = new FileStream(Path.Combine(albumFolderPath, photo.FileName), FileMode.Create))
                        {
                            photo.CopyTo(stream);
                        }
                    }
                }

                dataManager.GalleryAlbums.SaveGalleryAlbum(model);
                foreach (AlbumPhoto photo in model.AlbumPhotos)
                {
                    dataManager.AlbumPhotos.SaveAlbumPhoto(photo);
                }

                ViewBag.DataManager = dataManager;
                return View("Index",ViewBag.DataManager);
            }

            return View(model);
        }
    }
}
