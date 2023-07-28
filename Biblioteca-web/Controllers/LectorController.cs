using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Biblioteca.Application.Contract;
using Biblioteca.Application.Dtos.Lector;
using Biblioteca_web.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Biblioteca_web.Controllers
{
    public class LectorController : Controller
    {
      private readonly ILectorService lectorService;
      public LectorController (ILectorService lectorService)
        {
            this.lectorService = lectorService; 
        }
      public ActionResult Index() 
        {
            var result = this.lectorService.Get();
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            var lectores = ((List<Biblioteca.Infrestructure.Module.LectorModel>)result.Data)
                                                           .Select(cd => new Models.LectorModel()
                                                               {
                                                               IdLector = cd.IdLector,
                                                               Nombre = cd.Nombre,
                                                               Apellido = cd.Apellido,
                                                               Correo = cd.Correo,
                                                           }).ToList();
            return View(lectores);

        }
        public ActionResult Details(int id)
        {
            var result = this.lectorService.GetById(id);

            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }

            var lecto = (Biblioteca.Infrestructure.Module.LectorModel)result.Data;

            var lecModel =  new Models.LectorModel()
            {
                IdLector = lecto.IdLector,
                Nombre = lecto.Nombre,  
                Apellido = lecto.Apellido,
                Correo = lecto.Correo,  
            };

            return View(lecModel);

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LectorAddDto lectorAddDto)
        {
            try
            {
                var result = this.lectorService.Save(lectorAddDto);
                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var result = this.lectorService.GetById(id);
            if (!result.Success)
            {
                ViewBag.Message = result.Message;
                return View();
            }
            var lecto = (Biblioteca.Infrestructure.Module.LectorModel)result.Data;

            var lecModel = new Models.LectorModel()
            {
                IdLector = lecto.IdLector,
                Nombre = lecto.Nombre,
                Apellido = lecto.Apellido,
                Correo = lecto.Correo,
            };
            return View(lecto);
        }
        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LectorUpdateDto lectoUpdateDto)
        {
            try
            {
                var result = this.lectorService.Update(lectoUpdateDto);
                if (!result.Success)
                {
                    ViewBag.Message = result.Message;
                    return View();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            { 
                return View();
            }
        }

    }
}
