using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Biblioteca.Application.Contract;
using Biblioteca.Application.Dtos.Lector;
using Biblioteca_web.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Newtonsoft.Json;
using System.Text;
using Biblioteca_web.Models.Responses;

namespace Biblioteca_web.Controllers
{
    public class LectorController : Controller
    {

        HttpClientHandler httpClientHandler = new HttpClientHandler();
        public LectorController(IConfiguration configuration)
        {
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };

        }
        public ActionResult Index()
        {
            LectorResponse lectorReponse = new LectorResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {

                using (var response = httpClient.GetAsync("http://localhost:5292/api/Lector").Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        lectorReponse = JsonConvert.DeserializeObject<LectorResponse>(apiResponse);
                    }


                }
            }
            return View(lectorReponse.data);
        }

        public ActionResult Details(int id)
        {
            LectorDetailResponse courseDetailResponse = new LectorDetailResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {

                using (var response = httpClient.GetAsync("http://localhost:5037/api/Course/GetCourse?id=" + id).Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        courseDetailResponse = JsonConvert.DeserializeObject<LectorDetailResponse>(apiResponse);
                    }


                }
            }
            return View(courseDetailResponse.data);
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            LectorDetailResponse lectorDetailResponse = new LectorDetailResponse();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {

                using (var response = httpClient.GetAsync("http://localhost:5292/api/Lector" + id).Result)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        lectorDetailResponse = JsonConvert.DeserializeObject<LectorDetailResponse>(apiResponse);
                    }


                }
            }
            return View(lectorDetailResponse.data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LectorUpdateDto lectorUpdateDto)
        {
            try
            {

                var LectorAddResponse = new LectorAddResponse();



                using (var httpClient = new HttpClient(this.httpClientHandler))
                {


                    StringContent content = new StringContent(JsonConvert.SerializeObject(LectorAddResponse), Encoding.UTF8, "application/json");

                    using (var response = httpClient.PostAsync("http://localhost:5037/api/Course/Update", content).Result)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;

                        var result = JsonConvert.DeserializeObject<LectorAddResponse>(apiResponse);
                    }
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
