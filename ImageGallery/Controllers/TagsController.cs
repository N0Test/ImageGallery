using ImageGallery.Models;
using ImageGallery.Sevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageGallery.Controllers
{
    public class TagsController : Controller
    {
        private readonly ICRUDService<TagModel> _tagService;

        public TagsController(ICRUDService<TagModel> tagService)
        {
            _tagService = tagService;
        }

        public ActionResult Index()
        {
            var tags = _tagService.GetAll();
            return View(tags);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: TagController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TagModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var newImage = _tagService.CreateOrUpdate(model);

            if (newImage != null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var image = _tagService.Get(id);

            if (image == null) return NotFound();

            return View(image);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TagModel model)
        {
            var image = _tagService.Get(id);
            if (image == null) return NotFound();
            _tagService.Delete(image);
            return RedirectToAction("Index");
        }
    }
}
