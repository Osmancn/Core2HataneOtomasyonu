﻿using System;
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
    public class RandevuController : ControllerBase
    {
        IRandevuService service;
        public RandevuController(IRandevuService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ServiceResponse<Randevu> response = new ServiceResponse<Randevu>();

            Randevu Randevu = service.GetById(id);

            if (Randevu == null)
            {
                response.Errors.Add("Randevu bulunamadı");
                response.HasError = true;
                return BadRequest(response);
            }
            else
            {
                response.entity = Randevu;
                response.IsSuccessful = true;
                return Ok(response);
            }
        }

        [HttpGet("GetByDoktorId/{id}")]
        public IActionResult GetByDoktorId(int id)
        {
            ServiceResponse<Randevu> response = new ServiceResponse<Randevu>();

            List<Randevu> entities = service.GetByDoktorId(id);

            if (entities == null)
            {
                response.Errors.Add("Randevular bulunamadı");
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

        [HttpGet("GetByHastaId/{id}")]
        public IActionResult GetByHastaId(int id)
        {
            ServiceResponse<Randevu> response = new ServiceResponse<Randevu>();

            List<Randevu> entities = service.GetByHastaId(id);

            if (entities == null)
            {
                response.Errors.Add("Randevular bulunamadı");
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

        [HttpGet("GetByRandevu")]
        public IActionResult GetByRandevu([FromBody]RandevuViewModel model)
        {
            ServiceResponse<Randevu> response = new ServiceResponse<Randevu>();

            List<Randevu> entities = service.GetByRandevu(model.DoktorId,model.HastaId);

            if (entities == null)
            {
                response.Errors.Add("Randevular bulunamadı");
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
        public IActionResult Post([FromBody]Randevu model)
        {
            service.Create(model);
            ServiceResponse<Randevu> response = new ServiceResponse<Randevu>()
            {
                entity = model,
                IsSuccessful = true
            };
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Put([FromBody]Randevu model)
        {
            service.Update(model);
            ServiceResponse<Randevu> response = new ServiceResponse<Randevu>()
            {
                entity = model,
                IsSuccessful = true
            };
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]Randevu model)
        {
            service.Delete(model);
            ServiceResponse<Randevu> response = new ServiceResponse<Randevu>()
            {
                entity = model,
                IsSuccessful = true
            };
            return Ok(response);
        }
    }
}