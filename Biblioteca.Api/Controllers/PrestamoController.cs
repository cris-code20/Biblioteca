
using Biblioteca.Application.Contract;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Application.Dtos.Prestamo;
using Biblioteca.Application.Service;
using Biblioteca.Infrestructure.Interface;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoService prestamoService;

        public PrestamoController(IPrestamoService prestamoService) 
        {
            this.prestamoService = prestamoService;
        }

        // GET: api/<PrestamoController>
        [HttpGet]
        public IActionResult Get()
        {
            var prestamo = this.prestamoService.Get();

            if (!prestamo.Success)
                return BadRequest(prestamo);

            return Ok(prestamo);
        }

        // GET api/<PrestamoController>/5
        [HttpGet("{id}")]
        public  IActionResult Get(int id)
        {
            var prestamo = this.prestamoService.GetById(id);
            return Ok(prestamo);
        }

        // POST api/<PrestamoController>
        [HttpPost("Save")]
        public IActionResult Post([FromBody] PrestamoAddDto prestamoAdd)
        {
            var result = this.prestamoService.Save(prestamoAdd);
            return Ok(result);
        }

        // PUT api/<PrestamoController>/5
        [HttpPost("Update")]
        public IActionResult Put([FromBody] PrestamoUpdateDto prestamoUpdate )
        {
            var result = this.prestamoService.Update(prestamoUpdate);
            return Ok(result);

        }

        // DELETE api/<PrestamoController>/5
        [HttpPost("Remove")]
        public IActionResult Delete([FromBody] PrestamoRemoveDto prestamoRemove )
        {
            var result = this.prestamoService.Remove(prestamoRemove);
            return Ok(result);
        }
    }
}
    