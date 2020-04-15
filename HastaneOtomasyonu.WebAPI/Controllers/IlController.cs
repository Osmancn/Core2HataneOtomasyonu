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
    public class IlController : ControllerBase
    {
        IIlService service;
        public IlController(IIlService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ServiceResponse<Il> response = new ServiceResponse<Il>();

            Il il=service.GetById(id);

            if(il==null)
            {
                response.Errors.Add("il bulunamadı");
                response.HasError = true;
                return BadRequest(response);
            }
            else
            {
                response.entity = il;
                response.IsSuccessful = true;
                return Ok(response);
            }
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            ServiceResponse<Il> response = new ServiceResponse<Il>();
            List<Il> iller = service.GetAll();
            if(iller==null)
            {
                response.Errors.Add("İller getirilemedi");
                response.HasError = true;
                return BadRequest(response);
            }
            else
            {
                response.entities = iller;
                response.IsSuccessful = true;
                return Ok(response);
            }
        }

    }
}