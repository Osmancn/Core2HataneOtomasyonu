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
using RestSharp;

namespace HastaneOtomasyonu.WebUI.Controllers
{
    public class HastaController : Controller
    {
        public IActionResult Index() => RedirectToAction("Index", "Home");

        [HttpGet]
        public IActionResult Giris() => View();


        [HttpPost]
        public IActionResult Giris(GirisViewModel model)
        {

            RemoteService<Hasta> service = new RemoteService<Hasta>();

            ServiceResponse<Hasta> response = service.Post(model, "Hasta", "HastaLogin");
            if (response.isSuccessful)
            {
                //TODO Kullaniciyi sessionda tut
                HttpContext.Session.SetString("LoginType", "Hasta");
                HttpContext.Session.SetObjectAsJson("Hasta", response.entity);
                return RedirectToAction("index");
            }
            if (response.Errors != null)
                foreach (var item in response.Errors)
                    ModelState.AddModelError("Model", item);

            return View(model);
        }

        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KayitOl(KayitOlViewModel model)
        {
            RemoteService<Hasta> service = new RemoteService<Hasta>();
            Hasta hasta = new Hasta
            {
                Ad = model.Ad,
                Soyad = model.Soyad,
                Cinsiyet = model.Cinsiyet,
                Email = model.Email,
                Parola = model.Parola,
                TC = model.Tc
            };

            ServiceResponse<Hasta> response = service.Post(hasta, "hasta");

            if (response.isSuccessful)
                return RedirectToAction("Giris");

            if (response.Errors != null)
                foreach (var item in response.Errors)
                    ModelState.AddModelError("Model", item);


            return View(model);
        }

        public IActionResult Cikis()
        {
            HttpContext.Session.Remove("Hasta");
            HttpContext.Session.Remove("LoginType");
            return RedirectToAction("Index", "Home");
        }
    }
}