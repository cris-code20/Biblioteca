using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Application.Contract;
using Biblioteca.Application.Dtos.Lector;
using Biblioteca.Infrestructure.Exceptions;
using Biblioteca.Infrestructure.Interface;
using Biblioteca.Infrestructure.Module;
using Biblioteca.Infrestructure.Entities;

namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectorController : ControllerBase
    {
        private readonly ILectorService lectorService;

        public LectorController(ILectorService lectorService)
        {
            this.lectorService = this.lectorService;
        }
        [HttpGet("GetLector")]
        public IActionResult Get()
        {
            var result = this.lectorService.Get();

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);
        }


        [HttpGet("GetLector")]
        public IActionResult Get([FromQuery] int id)
        {
            var result = this.lectorService.GetById(id);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);

        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] LectorAddDto lectorAddDto)
        {
            var result = this.lectorService.Save(lectorAddDto);

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Put([FromBody] Lector lector)
        {
            //this.LectorRepository.Update(lector);
            return Ok();
        }


    }
}