using ImageGallery.Models;
using ImageGallery.Sevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGallery.Controllers
{
    public class ImagesController : Controller
    {
        private readonly ICRUDService<ImageModel> _imageService;
        private readonly ICRUDService<TagModel> _tagService;
        private readonly IImageBlobService _blobService;

        public ImagesController(ICRUDService<ImageModel> imageService, IImageBlobService blobService, ICRUDService<TagModel> tagService)
        {
            _imageService = imageService;
            _tagService = tagService;
            _blobService = blobService;
        }

        public ActionResult Index(int id)
        {
            var image = _imageService.Get(id);
            if(image == null) return NotFound();
            return View(image);
        }

        // GET: ImagesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImagesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([FromForm] ImageModel model, [FromForm] IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var fileName = await _blobService.Upload(file.FileName, file.OpenReadStream());
                model.Url = fileName;
            }
            catch (System.Exception)
            {

                throw;
            }
            model.Tags = new List<TagModel>();

            var newImage = _imageService.CreateOrUpdate(model);

            if (newImage != null)
            {
                return RedirectToAction("Index", new { id = newImage.Id });
            }

            return View(model);
        }

        // GET: ImagesController/Edit/5
        public ActionResult Edit(int id)
        {
            var image = _imageService.Get(id);
            var tags = _tagService.GetAll();
            ViewData["Image"] = image;

            if( image == null) return NotFound();

            return View(tags);
        }

        // POST: ImagesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, int[] tags)
        {
            var _tags = _tagService.GetAll();

            var model = _imageService.Get(id);

            model.Tags = _tags.Where(tag => tags.Contains(tag.Id)).ToList();

            var newImage = _imageService.CreateOrUpdate(model);

            if (newImage != null)
            {
                return RedirectToAction("Index", new { id });
            }

            return View(_tags);
        }

        // GET: ImagesController/Delete/5
        public ActionResult Delete(int id)
        {
            var image = _imageService.Get(id);

            if (image == null) return NotFound();

            return View(image);
        }

        // POST: ImagesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ImageModel model)
        {
            var image = _imageService.Get(id);
            if(image == null) return NotFound();
            var deleted = _imageService.Delete(image);
            if(!deleted)
            {
                return RedirectToAction("Index", new { id });
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
