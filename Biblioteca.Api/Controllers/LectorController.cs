using Biblioteca.Infrestructure.Interface;
using Microsoft.AspNetCore.Mvc;

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

        // GET: api/<LectorController>
        [HttpGet]
        public IActionResult Get()
        {
            var LectorRepository = this.LectorRepository.GetEntities();
            return Ok(LectorRepository);
        }

        // GET api/<LectorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LectorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LectorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LectorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}