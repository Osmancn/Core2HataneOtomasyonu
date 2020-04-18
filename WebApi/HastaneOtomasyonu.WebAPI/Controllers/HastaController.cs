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
    public class HastaController : ControllerBase
    {
        IHastaService service;
        public HastaController(IHastaService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ServiceResponse<Hasta> response = new ServiceResponse<Hasta>();

            Hasta entity = service.GetByID(id);

            if (entity == null)
            {
                response.Errors.Add("Hasta bulunamadı");
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

     

        [HttpPost("HastaLogin")]
        public IActionResult Post([FromBody]LoginViewModel model)
        {
            ServiceResponse<Hasta> response = new ServiceResponse<Hasta>();
            Hasta entity = service.GetByHasta(model.Tc, model.Parola);
            if (entity == null)
            {
                response.Errors.Add("Hasta bulunamadı");
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
        public IActionResult Post([FromBody]Hasta model)
        {
            ServiceResponse<Hasta> response = new ServiceResponse<Hasta>();
            if (service.GetByTc(model.TC))
            {
                response.Errors.Add("böyle bir tcli Hasta var");
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
        public IActionResult Put([FromBody]Hasta model)
        {
            service.Update(model);
            ServiceResponse<Hasta> response = new ServiceResponse<Hasta>()
            {
                entity = model,
                IsSuccessful = true
            };
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]Hasta model)
        {
            service.Delete(model);
            ServiceResponse<Hasta> response = new ServiceResponse<Hasta>()
            {
                entity = model,
                IsSuccessful = true
            };
            return Ok(response);
        }
    }
}
