using Biblioteca.Infrestructure.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly IprestamosRepository prestamosRepository;

        public PrestamoController(IprestamosRepository prestamosRepository) 
        {
            this.prestamosRepository = prestamosRepository;
        }

        // GET: api/<PrestamoController>
        [HttpGet]
        public IActionResult Get()
        {
            var prestamosRepository = this.prestamosRepository.GetEntities();
            return Ok(prestamosRepository);
        }

        // GET api/<PrestamoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PrestamoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PrestamoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PrestamoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
