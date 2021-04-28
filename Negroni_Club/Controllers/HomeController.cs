using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Negroni_Club.Domain.Repositories;
using Negroni_Club.Models;


namespace Negroni_Club.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly DataManager dataManager;

        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            ViewBag.DataManager = dataManager;
            return View(ViewBag.DataManager);
        }
        //[HttpGet]
        //public IActionResult AboutUsPartial()
        //{
        //    return PartialView(dataManager.TextFields.GetTextFieldByCodeWord("AboutUs"));
        //}

        public IActionResult AlbumPhotoList(Guid id)
        {
            var album = dataManager.GalleryAlbums.GetGalleryAlbumById(id);

            return View("AlbumPhotoList", album);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
