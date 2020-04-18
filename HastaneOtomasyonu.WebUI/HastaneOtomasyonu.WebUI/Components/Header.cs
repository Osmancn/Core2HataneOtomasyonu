using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneOtomasyonu.WebUI.Components
{
    public class Header:ViewComponent
    {
        public Header()
        {

        }

        public IViewComponentResult Invoke()
        {

            if (HttpContext.Session.GetString("LoginType") == "Hasta")
                return View("Hasta");

            else if (HttpContext.Session.GetString("LoginType") == "Doktor")
                return View("Doktor");

            else if(HttpContext.Session.GetString("LoginType") == "Admin")
                return View("Admin");

            return View();
        }
    }
}
