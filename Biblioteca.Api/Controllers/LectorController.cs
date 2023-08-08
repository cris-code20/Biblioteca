using Biblioteca.Application.Contract;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Application.Dtos.Lector;
using Biblioteca.Application.Service;
using Biblioteca.Application.Dtos.Department;

namespace Biblioteca.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LectorController : ControllerBase
    {
        private readonly ILectorService lectorService;

        public LectorController(ILectorService lectorService)
        {
            this.lectorService = lectorService;
        }
        [HttpGet]
        public IActionResult GetLectors()
        {
            var lector = this.lectorService.Get();
            if (!lector.Success)
                return BadRequest(lector);
            return Ok(lector);
        }


        [HttpGet("{id}")]
        public IActionResult GetLectorById(int id)
        {
            var lector = this.lectorService.GetById(id);
            return Ok(lector);

        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] LectorAddDto lectorAddDto)
        {
            var lector = this.lectorService.Save(lectorAddDto);
            return Ok(lector);
        }

        [HttpPost("Update")]
        public IActionResult Put([FromBody] LectorUpdateDto lectorUpdateDto)
        {
            var lector = this.lectorService.Update(lectorUpdateDto);
            return Ok();
        }
        [HttpPost("Remove")]
        public IActionResult Remove([FromBody] LectorRemoveDto lectorRemoveDto)
        {
            var lector = this.lectorService.Remove(lectorRemoveDto);
            return Ok();
        }


    }
}