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
    public class DoktorController : ControllerBase
    {
        IDoktorService service;
        public DoktorController(IDoktorService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ServiceResponse<Doktor> response = new ServiceResponse<Doktor>();

            Doktor entity = service.GetById(id);

            if (entity == null)
            {
                response.Errors.Add("Doktor bulunamadı");
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

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            ServiceResponse<Doktor> response = new ServiceResponse<Doktor>();
            List<Doktor> doktorlar = service.GetAll();
            if (doktorlar == null)
            {
                response.Errors.Add("doktorlar getirilemedi");
                response.HasError = true;
                return BadRequest(response);
            }
            else
            {
                response.entities = doktorlar;
                response.IsSuccessful = true;
                return Ok(response);
            }
        }

        [HttpGet("GetByBolumId/{id}")]
        public IActionResult GetByBolumId(int id)
        {
            ServiceResponse<Doktor> response = new ServiceResponse<Doktor>();

            List<Doktor> entities = service.GetByBolumId(id);

            if (entities == null)
            {
                response.Errors.Add("Doktorlar bulunamadı");
                response.HasError = true;
                return BadRequest(response);
            }
            else
            {
                response.entities = entities;
                response.IsSuccessful = true;
                return Ok(response);
            }
        }

        [HttpPost("doktorLogin")]
        public IActionResult Post([FromBody]LoginViewModel model)
        {
            ServiceResponse<Doktor> response = new ServiceResponse<Doktor>();
            Doktor entity = service.GetByDoktor(model.Tc, model.Parola);
            if (entity == null)
            {
                response.Errors.Add("Doktor bulunamadı");
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

        [HttpPost]
        public IActionResult Post([FromBody]Doktor model)
        {
            ServiceResponse<Doktor> response = new ServiceResponse<Doktor>();
            if (service.GetByTc(model.TC))
            {
                response.Errors.Add("böyle bir tcli doktor var");
                response.HasError = true;
                return BadRequest(response);
            }
            else
            {
                service.Create(model);
                response.entity = model;
                response.IsSuccessful = true;
                return Ok(response);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]Doktor model)
        {
            service.Update(model);
            ServiceResponse<Doktor> response = new ServiceResponse<Doktor>()
            {
                entity = model,
                IsSuccessful = true
            };
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]Doktor model)
        {
            service.Delete(model);
            ServiceResponse<Doktor> response = new ServiceResponse<Doktor>()
            {
                entity = model,
                IsSuccessful = true
            };
            return Ok(response);
        }
    }
}
