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
            this.lectorService = this.lectorService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.lectorService.Get();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = this.lectorService.GetById(id);
            return Ok(result);

        }

        [HttpPost("Save")]
        public IActionResult Post([FromBody] LectorAddDto lectorAddDto)
        {
            var result = this.lectorService.Save(lectorAddDto);
            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Put([FromBody] LectorUpdateDto lectorUpdateDto)
        {
            var result = this.lectorService.Update(lectorUpdateDto);
            return Ok();
        }
        [HttpPost("Remove")]
        public IActionResult Remove([FromBody] LectorRemoveDto lectorRemoveDto)
        {
            var result = this.lectorService.Remove(lectorRemoveDto);
            return Ok();
        }


    }
}