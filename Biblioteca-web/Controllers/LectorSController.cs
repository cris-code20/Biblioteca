using Biblioteca.Application.Contract;
using Biblioteca.Infrestructure.Module;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_web.Controllers
{
    public class LectorSController : Controller
    {

        private readonly ILectorService lectorService;

        public LectorSController(ILectorService lectorService)
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

            var lecstor = (List<LectorModel>)result.Data;

            return View(lecstor);


        }

    }
}