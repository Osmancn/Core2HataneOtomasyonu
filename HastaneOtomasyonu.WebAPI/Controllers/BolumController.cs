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
    public class BolumController : ControllerBase
    {
        IBolumService service;
        public BolumController(IBolumService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ServiceResponse<Bolum> response = new ServiceResponse<Bolum>();

            Bolum entity= service.GetById(id);

            if (entity == null)
            {
                response.Errors.Add("Bolum bulunamadı");
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

        [HttpGet("getbyhastaneid/{id}")]
        public IActionResult GetByHastaneId(int id)
        {
            ServiceResponse<Bolum> response = new ServiceResponse<Bolum>();

            List<Bolum> entities = service.GetByHastaneId(id);

            if (entities == null)
            {
                response.Errors.Add("Bolumler bulunamadı");
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
        public IActionResult Post([FromBody]Bolum model)
        {
            service.Create(model);
            ServiceResponse<Bolum> response = new ServiceResponse<Bolum>()
            {
                entity = model,
                IsSuccessful = true
            };
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Put([FromBody]Bolum model)
        {
            service.Update(model);
            ServiceResponse<Bolum> response = new ServiceResponse<Bolum>()
            {
                entity = model,
                IsSuccessful = true
            };
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]Bolum model)
        {
            service.Delete(model);
            ServiceResponse<Bolum> response = new ServiceResponse<Bolum>()
            {
                entity = model,
                IsSuccessful = true
            };
            return Ok(response);
        }
    }
}