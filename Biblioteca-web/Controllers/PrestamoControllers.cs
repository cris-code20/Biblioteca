using Biblioteca.Application.Contract;
using Biblioteca.Domain.Entitis;
using Biblioteca.Infrestructure.Module;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca_web.Controllers
{
    public class PrestamoControllers : Controller
    {

        private readonly IPrestamoService prestamoService; 

        public PrestamoControllers(IPrestamoService prestamoService)
        {
            this.prestamoService = prestamoService;
        }

        public ActionResult Index()
        {
            var result = prestamoService.Get();

            if (!result.Success)
            {
                ViewBag.Message = result.Message;

            }

            var presramo = (List<prestamoModels>)result.Data;
                
            return View(presramo);


        }

    }
}
