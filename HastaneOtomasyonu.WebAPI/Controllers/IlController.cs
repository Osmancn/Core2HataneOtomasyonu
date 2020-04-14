using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HastaneOtomasyonu.Bussiness.Abstract;
using HastaneOtomasyonu.Entity;
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

        [HttpGet("getbyId/{id}")]
        public IActionResult GetById(int id)
        {
            Il il=service.GetById(id);
            return Ok(il);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            List<Il> iller = service.GetAll();
            return Ok(iller);
        }

    }
}