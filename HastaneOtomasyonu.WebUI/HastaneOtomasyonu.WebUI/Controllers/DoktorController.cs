using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HastaneOtomasyonu.Entity;
using HastaneOtomasyonu.WebUI.Extensions;
using HastaneOtomasyonu.WebUI.Models;
using HastaneOtomasyonu.WebUI.Service;
using HastaneOtomasyonu.WebUI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HastaneOtomasyonu.WebUI.Controllers
{
    public class DoktorController : Controller
    {
        public IActionResult Index() => RedirectToAction("Index", "Home");

        public IActionResult Giris() => View();


        [HttpPost]
        public IActionResult Giris(GirisViewModel model)
        {
            RemoteService<Doktor> service = new RemoteService<Doktor>();
            ServiceResponse<Doktor> response = service.Post(model, "Doktor", "doktorLogin");
            if (response.isSuccessful)
            {
                //TODO Kullaniciyi sessionda tut
                HttpContext.Session.SetString("LoginType", "Doktor");
                HttpContext.Session.SetObjectAsJson("Doktor", response.entity);
                return RedirectToAction("index");
            }
            if (response.Errors != null)
                foreach (var item in response.Errors)
                    ModelState.AddModelError("Model", item);

            return View(model);
        }

        public IActionResult Cikis()
        {
            HttpContext.Session.Remove("Doktor");
            HttpContext.Session.Remove("LoginType");
            return RedirectToAction("Index", "Home");
        }
    }
}