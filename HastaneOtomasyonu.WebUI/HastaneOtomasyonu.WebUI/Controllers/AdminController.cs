using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HastaneOtomasyonu.Entity;
using HastaneOtomasyonu.WebUI.Extensions;
using HastaneOtomasyonu.WebUI.Models;
using HastaneOtomasyonu.WebUI.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HastaneOtomasyonu.WebUI.Controllers
{
    public class AdminController : Controller
    {

        public IActionResult Index()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("LoginType")))
                return RedirectToAction("Giris");
            return RedirectToAction("Index", "Home");
        }

        //Account İşlemler
        public IActionResult Giris() => View();

        [HttpPost]
        public IActionResult Giris(Admin model)
        {
            RemoteService<Admin> service = new RemoteService<Admin>();
            ServiceResponse<Admin> response = service.Post(model, "Admin");
            if (response.isSuccessful)
            {
                //TODO Kullaniciyi sessionda tut
                HttpContext.Session.SetString("LoginType", "Admin");
                HttpContext.Session.SetObjectAsJson("Admin", response.entity);
                return RedirectToAction("index");
            }
            if (response.Errors != null)
                foreach (var item in response.Errors)
                    ModelState.AddModelError("Model", item);

            return View(model);
        }

        public IActionResult Cikis()
        {
            HttpContext.Session.Remove("Admin");
            HttpContext.Session.Remove("LoginType");
            return RedirectToAction("Index", "Home");
        }



        public JsonResult HastanelerGetByIlId(int id)
        {
            RemoteService<Hastane> service = new RemoteService<Hastane>();
            ServiceResponse<Hastane> resposen = service.GetById(id,"Hastane", "GetByIlId");
            if (resposen.isSuccessful)
                return Json(resposen.entities);
            return null;
        }

        public JsonResult BolumlerGetByHastaneId(int id)
        {
            RemoteService<Bolum> service = new RemoteService<Bolum>();
            ServiceResponse<Bolum> resposen = service.GetById(id, "Bolum", "getbyhastaneid");
            if (resposen.isSuccessful)
                return Json(resposen.entities);
            return null;
        }

        public JsonResult DoktorlarGetByBolumId(int id)
        {
            RemoteService<Doktor> service = new RemoteService<Doktor>();
            ServiceResponse<Doktor> resposen = service.GetById(id, "Bolum", "GetByBolumId");
            if (resposen.isSuccessful)
                return Json(resposen.entities);
            return null;
        }


        //                   //
        // Hastane İşlemleri //
        //                   //

        public IActionResult HastaneListesi()
        {
            RemoteService<Hastane> service = new RemoteService<Hastane>();
            ServiceResponse<Hastane> response = service.Get("Hastane", "getall");
            if (response.isSuccessful)
                return View(response.entities);

            return RedirectToAction("Index");
        }

        public IActionResult HastaneEkle()
        {
            RemoteService<Il> service = new RemoteService<Il>();
            ServiceResponse<Il> response = service.Get("Il", "getall");
            if (response.isSuccessful)
            {
                ViewBag.Iller = new SelectList(response.entities, "ilId", "ilAdi");
                return View();
            }
            return RedirectToAction("HastaneListesi");
        }

        [HttpPost]
        public IActionResult HastaneEkle(Hastane model)
        {
            RemoteService<Hastane> service = new RemoteService<Hastane>();
            ServiceResponse<Hastane> response = service.Post(model, "Hastane");

            if (response.isSuccessful)
                return RedirectToAction("HastaneListesi");

            if (response.Errors != null)
                foreach (var item in response.Errors)
                    ModelState.AddModelError("Model", item);


            return View(model);
        }

        public IActionResult HastaneDuzenle(int id)
        {
            RemoteService<Il> ilService = new RemoteService<Il>();
            RemoteService<Hastane> hastaneService = new RemoteService<Hastane>();
            ServiceResponse<Il> ilResponse = ilService.Get("Il", "getall");
            if (ilResponse.isSuccessful)
            {
                ViewBag.Iller = new SelectList(ilResponse.entities, "ilId", "ilAdi");
                ServiceResponse<Hastane> hastaneResponse = hastaneService.GetById(id, "Hastane");
                if (hastaneResponse.isSuccessful)
                    return View(hastaneResponse.entity);
            }
            return RedirectToAction("HastaneListesi");
        }

        [HttpPost]
        public IActionResult HastaneDuzenle(Hastane model)
        {
            RemoteService<Hastane> service = new RemoteService<Hastane>();
            ServiceResponse<Hastane> response = service.Put(model, "Hastane");
            if (response.isSuccessful)
                return RedirectToAction("HastaneListesi");
            return View(model);
        }

        public IActionResult HastaneSil(int id)
        {
            RemoteService<Hastane> service = new RemoteService<Hastane>();
            ServiceResponse<Hastane> hastane = service.GetById(id, "Hastane");
            if(hastane.isSuccessful)
            {
                ServiceResponse<Hastane> response = service.Delete(hastane.entity, "Hastane");
            }
            return RedirectToAction("HastaneListesi");
        }



        //                 //
        // Bölüm İşlemleri //
        //                 //
       
        [HttpGet]
        public IActionResult BolumListesi(int? id)//id = hastane id
        {
            RemoteService<Bolum> service = new RemoteService<Bolum>();
            ServiceResponse<Bolum> response;
            if (id==null)
            {
                response = service.Get("Bolum", "getall");
                if (response.isSuccessful)
                    return View(response.entities);
            }

            response = service.GetById(id.GetValueOrDefault(),"Bolum", "getbyhastaneid");
            if (response.isSuccessful)
                return View(response.entities);

            return RedirectToAction("Index");
        }

        public IActionResult BolumEkle()
        {
            
            RemoteService<Il> service = new RemoteService<Il>();
            ServiceResponse<Il> response = service.Get("Il", "getall");
            if (response.isSuccessful)
            {
                ViewBag.iller = new SelectList(response.entities, "ilId", "ilAdi");
                ViewBag.hastaneler = new SelectList(new List<Hastane>(), "HastaneId", "HastaneAdi");
                return View();
            }
            return RedirectToAction("BolumListesi");
        }

        [HttpPost]
        public IActionResult BolumEkle(Bolum model)
        {
            RemoteService<Bolum> service = new RemoteService<Bolum>();
            ServiceResponse<Bolum> response = service.Post(model, "Bolum");

            if (response.isSuccessful)
                return RedirectToAction("BolumListesi");

            if (response.Errors != null)
                foreach (var item in response.Errors)
                    ModelState.AddModelError("Model", item);


            return View(model);
        }

        public IActionResult BolumDuzenle(int id)//id = bölüm id
        {
            RemoteService<Bolum> bolumService = new RemoteService<Bolum>();
            RemoteService<Hastane> hastaneService = new RemoteService<Hastane>();
            ServiceResponse<Hastane> hastaneResponse = hastaneService.Get("Hastane", "getall");
            if (hastaneResponse.isSuccessful)
            {
                ViewBag.hastaneler = new SelectList(hastaneResponse.entities, "HastaneId", "HastaneAdi");
                ServiceResponse<Bolum> bolumResponse = bolumService.GetById(id, "Bolum");
                if (bolumResponse.isSuccessful)
                    return View(bolumResponse.entity);
            }
            return RedirectToAction("BolumListesi");
        }

        [HttpPost]
        public IActionResult BolumDuzenle(Bolum model)
        {
            RemoteService<Bolum> service = new RemoteService<Bolum>();
            ServiceResponse<Bolum> response = service.Put(model, "Bolum");
            if (response.isSuccessful)
                return RedirectToAction("BolumListesi");
            return View(model);
        }

        public IActionResult BolumSil(int id)
        {
            RemoteService<Bolum> service = new RemoteService<Bolum>();
            ServiceResponse<Bolum> bolum = service.GetById(id, "Bolum");
            if (bolum.isSuccessful)
            {
                ServiceResponse<Bolum> response = service.Delete(bolum.entity, "Hastane");
            }
            return RedirectToAction("BolumListesi");
        }


        //                  //
        // Doktor İşlemleri //
        //                  //

        public IActionResult DoktorListesi(int? id)//id = Bolum id
        {
            RemoteService<Doktor> service = new RemoteService<Doktor>();
            ServiceResponse<Doktor> response;
            if (id == null)
            {
                response = service.Get("Doktor", "getall");
                if (response.isSuccessful)
                    return View(response.entities);
            }

            response = service.GetById(id.GetValueOrDefault(), "Doktor", "GetByBolumId");
            if (response.isSuccessful)
                return View(response.entities);

            return RedirectToAction("Index");
        }

        public IActionResult DoktorEkle()
        {
            RemoteService<Doktor> service = new RemoteService<Doktor>();
            ServiceResponse<Doktor> response = service.Get("Doktor", "getall");
            if (response.isSuccessful)
            {
                ViewBag.bolumler = new SelectList(response.entities, "BolumId", "BolumAdi");
                return View();
            }
            return RedirectToAction("DoktorListesi");
        }

        [HttpPost]
        public IActionResult DoktorEkle(Bolum model)
        {
            RemoteService<Doktor> service = new RemoteService<Doktor>();
            ServiceResponse<Doktor> response = service.Post(model, "Doktor");

            if (response.isSuccessful)
                return RedirectToAction("DoktorListesi");

            if (response.Errors != null)
                foreach (var item in response.Errors)
                    ModelState.AddModelError("Model", item);


            return View(model);
        }

        public IActionResult DoktorDuzenle(int id)//id = bölüm id
        {
            RemoteService<Bolum> bolumService = new RemoteService<Bolum>();
            RemoteService<Doktor> doktorService = new RemoteService<Doktor>();
            ServiceResponse<Bolum> hastaneResponse = bolumService.Get("Bolum", "getall");
            if (hastaneResponse.isSuccessful)
            {
                ViewBag.bolumler = new SelectList(hastaneResponse.entities, "BolumId", "BolumAdi");
                ServiceResponse<Doktor> doktorResponse = doktorService.GetById(id, "Doktor");
                if (doktorResponse.isSuccessful)
                    return View(doktorResponse.entity);
            }
            return RedirectToAction("DoktorListesi");
        }

        [HttpPost]
        public IActionResult DoktorDuzenle(Bolum model)
        {
            RemoteService<Doktor> service = new RemoteService<Doktor>();
            ServiceResponse<Doktor> response = service.Put(model, "Doktor");
            if (response.isSuccessful)
                return RedirectToAction("DoktorListesi");
            return View(model);
        }

        public IActionResult DoktorSil(int id)// id = doktor id
        {
            RemoteService<Doktor> service = new RemoteService<Doktor>();
            ServiceResponse<Doktor> doktor = service.GetById(id, "Doktor");
            if (doktor.isSuccessful)
            {
                ServiceResponse<Doktor> response = service.Delete(doktor.entity, "Doktor");
            }
            return RedirectToAction("DoktorListesi");
        }
    }
}