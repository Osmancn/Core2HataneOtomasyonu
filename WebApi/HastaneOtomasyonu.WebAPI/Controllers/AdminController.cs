using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HastaneOtomasyonu.Bussiness.Abstract;
using HastaneOtomasyonu.Entity;
using HastaneOtomasyonu.WebAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HastaneOtomasyonu.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IAdminService service;
        public AdminController(IAdminService service)
        {
            this.service = service;
        }


        [HttpPost]
        public IActionResult Post([FromBody]AdminViewModel model)
        {
            ServiceResponse<Admin> response = new ServiceResponse<Admin>();

            Admin entity = service.GetByAdmin(model.KullaniciAdi,model.Parola);
            if(entity==null)
            {
                response.Errors.Add("Kullanici adı veya parola yanlış");
                response.HasError = true;
                return BadRequest(response);
            }
            else
            {
                response.entity = entity;
                response.IsSuccessful = true;
                return Ok(response);
            }
        }
    }
}