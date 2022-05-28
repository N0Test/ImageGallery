using ImageGallery.Models;
using ImageGallery.Sevices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;

namespace ImageGallery.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var token = _authorizationService.LogIn(model);

            if (token != null)
            {
                HttpContext.Session.Set("tokenKey", Encoding.ASCII.GetBytes(token.AccessToken));
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var token = _authorizationService.Registration(model);

            if (token != null)
            {
                HttpContext.Session.Set("tokenKey", Encoding.ASCII.GetBytes(token.AccessToken));
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("tokenKey");
            return RedirectToAction("Index", "Home");
        }
    }
}
