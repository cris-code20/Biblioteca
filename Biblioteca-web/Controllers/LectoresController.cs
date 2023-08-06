using Biblioteca.Application.Contract;
using Biblioteca.Infrestructure.Module;
using Biblioteca_web.Models;
using Microsoft.AspNetCore.Mvc;
namespace Biblioteca_web.Controllers
{
    public class LectoresController : Controller
    {

        private readonly ILectorService lectorService;

        public LectoresController(ILectorService lectorService)
        {
            this.lectorService = lectorService;
        }

        public ActionResult Index()
        {
            var result = lectorService.Get();

            if (!result.Success)
            {
                ViewBag.Message = result.Message;

            }

            var lectors = (List<LectorModels>)result.Data;

            return View(lectors);


        }

    }
}