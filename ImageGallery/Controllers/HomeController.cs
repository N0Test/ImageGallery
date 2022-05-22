using ImageGallery.Models;
using ImageGallery.Sevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IImageSearchService _searchService;

        public HomeController(ILogger<HomeController> logger, IImageSearchService searchService)
        {
            _logger = logger;
            _searchService = searchService;
        }

        public IActionResult Index([FromQuery] string q, [FromQuery] int? tag)
        {
            ViewData["SearchQuery"] = q;

            var images = _searchService.Search(q, tag);

            return View(images);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
