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
    public class HastaneController : ControllerBase
    {
        IHastaneService service;
        public HastaneController(IHastaneService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ServiceResponse<Hastane> response = new ServiceResponse<Hastane>();

            Hastane entity = service.GetById(id);

            if (entity == null)
            {
                response.Errors.Add("Hastane bulunamadı");
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
            ServiceResponse<Hastane> response = new ServiceResponse<Hastane>();
            List<Hastane> hastaneler = service.GetAll();
            if (hastaneler == null)
            {
                response.Errors.Add("hastaneler getirilemedi");
                response.HasError = true;
                return BadRequest(response);
            }
            else
            {
                response.entities = hastaneler;
                response.IsSuccessful = true;
                return Ok(response);
            }
        }

        [HttpGet("GetByIlId/{id}")]
        public IActionResult GetByIlId(int id)
        {
            ServiceResponse<Hastane> response = new ServiceResponse<Hastane>();

            List<Hastane> entities = service.GetByIlId(id);

            if (entities == null)
            {
                response.Errors.Add("Hastaneler bulunamadı");
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

        [HttpPost]
        public IActionResult Post([FromBody]Hastane model)
        {
            service.Create(model);
            ServiceResponse<Hastane> response = new ServiceResponse<Hastane>()
            {
                entity = model,
                IsSuccessful = true
            };
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Put([FromBody]Hastane model)
        {
            service.Update(model);
            ServiceResponse<Hastane> response = new ServiceResponse<Hastane>()
            {
                entity = model,
                IsSuccessful = true
            };
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]Hastane model)
        {
            service.Delete(model);
            ServiceResponse<Hastane> response = new ServiceResponse<Hastane>()
            {
                entity = model,
                IsSuccessful = true
            };
            return Ok(response);
        }
    }
}