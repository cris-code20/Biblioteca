using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Application.Contract;
using Biblioteca.Application.Dtos.Lector;
using Biblioteca.Infrestructure.Module;

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
                ViewBag.Message = result.Message;

            var lectors = (List<LectorModel>)result.Data;

            return View(lectors);

        }

        public ActionResult Details(int id)
        {
            var result = lectorService.GetById(id);

            if (!result.Success)
                ViewBag.Message = result.Message;


            var lector = (LectorModel)result.Data;

            return View(lector);
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
            var result = lectorService.GetById(id);

            if (!result.Success)
                ViewBag.Message = result.Message;


            var departmet = (LectorModel)result.Data;

            return View(departmet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LectorUpdateDto lectorUpdateDto)
        {
            try
            {
                var result = this.lectorService.Update(lectorUpdateDto);


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