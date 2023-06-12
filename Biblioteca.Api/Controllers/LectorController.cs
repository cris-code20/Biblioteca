using Microsoft.AspNetCore.Mvc;
using Biblioteca.Infrestructure.Interface;

namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LectorController : ControllerBase
    {
        private readonly ILector LectorRepository;

        public LectorController(ILector LectorRepository)
        {
            this.LectorRepository = LectorRepository;
        }

        // GET: api/<PrestamoController>
        [HttpGet]
        public IActionResult Get()
        {
            var LectorRepository = this.LectorRepository.GetEntities();
            return Ok(LectorRepository);
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