

using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Api.Controllers
{
    [Router("api/[Controller]")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {
        private readonly IprestamosRepository PresatamoRepositories;

        public PrestamosController (IprestamosRepository presatamoRepositories)
        {
            this.PresatamoRepositories = presatamoRepositories;

        }
        [HttpGet]
        public IActionResult Get()
        {
            var Prestamos = this.PresatamoRepositories.GetPrestamos();
            return Ok(Prestamos);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Presto = this.PresatamoRepositories.GetPrestamosById(id);
            return Ok(Presto);
        }
        [HttpPost("Save")]
        public void Post([FromBody] Prestamos prestamos)
        {

        }
        [HttpPost("Update")]
        public void Put([FromBody] Prestamos prestamos)
        {

        }
        [HttpPost("Remove")]
        public void Delete([FromBody] Prestamos prestamos)
        {

        }
    }
}
