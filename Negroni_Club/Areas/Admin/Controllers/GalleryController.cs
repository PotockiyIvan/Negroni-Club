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
        private readonly IWebHostEnvironment hostingEnvironment;
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

        [HttpGet]
        public IActionResult EditAlbum(Guid id)
        {
            var entity = id == default ? new GalleryAlbum() : dataManager.GalleryAlbums.GetGalleryAlbumById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult EditAlbum(GalleryAlbum model, List<IFormFile> photos)
        {
            if (ModelState.IsValid)
            {
                string albumFolderPath = hostingEnvironment.WebRootPath + "/images/gallery/album from " + model.EventDate.ToShortDateString();

                //Действие для записи нового альбома
                if (photos != null & model.AlbumPhotos == null)
                {
                    Directory.CreateDirectory(albumFolderPath);
                    model.AlbumPhotos = new List<AlbumPhoto>();
                    SavePhotos(model, photos, albumFolderPath);
                }

                //Действие для дополнения альбома
                else if (photos != null & model.AlbumPhotos.Count > 0)
                    SavePhotos(model, photos, albumFolderPath);

                else//Действие для изменения свойств модели без добавления фото
                    dataManager.GalleryAlbums.SaveGalleryAlbum(model);


                ViewBag.DataManager = dataManager;
                return View("Index", ViewBag.DataManager);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteAlbum(Guid id)
        {
            var album = dataManager.GalleryAlbums.GetGalleryAlbumById(id);

            Directory.Delete(hostingEnvironment.WebRootPath + "/images/gallery/album from " + album.EventDate.ToShortDateString(), true);

            foreach (AlbumPhoto photo in album.AlbumPhotos.ToList())
                dataManager.AlbumPhotos.DeleteAlbumPhoto(photo.Id);

            dataManager.GalleryAlbums.DeleteGalleryAlbum(id);

            ViewBag.DataManager = dataManager;
            return View("Index", ViewBag.DataManager);
        }


        private void SavePhotos(GalleryAlbum model, List<IFormFile> photos, string albumFolderPath)
        {
            foreach (IFormFile photo in photos)
            {
                AlbumPhoto albumPhoto = new AlbumPhoto { AlbumPhotoPath = photo.FileName };
                model.AlbumPhotos.Add(albumPhoto);

                using (var stream = new FileStream(Path.Combine(albumFolderPath, photo.FileName), FileMode.Create))
                    photo.CopyTo(stream);

            }

            dataManager.GalleryAlbums.SaveGalleryAlbum(model);

            foreach (AlbumPhoto photo in model.AlbumPhotos)
                dataManager.AlbumPhotos.SaveAlbumPhoto(photo);

        }
    }
}
