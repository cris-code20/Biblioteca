using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Biblioteca_web.Models.Responses;
using Biblioteca_web.Services;

namespace Biblioteca_web.Controllers
{
	public class LectoresController : Controller
	{
		private readonly ILectorApiService lectorApiService;

		private readonly IHttpClientFactory httpClientFactory;
		private readonly IConfiguration configuration;
		private readonly ILogger<LectoresController> logger;
		private string baseUrl = string.Empty;
		public LectoresController(ILectorApiService lectorApiService)
		{
			this.httpClientFactory = httpClientFactory;
			this.configuration = configuration;
			this.logger = logger;
			this.baseUrl = this.configuration["ApiConfig:baseUrl"];
			this.lectorApiService = lectorApiService;
		}
		public ActionResult Index()
		{
			LectorListResponse lectorReponse = new LectorListResponse();


			lectorReponse = this.lectorApiService.GetLectores();

			try
			{
			    using (var httpClient = this.httpClientFactory.CreateClient())
			    {
			        using (var response = httpClient.GetAsync($"{this.baseUrl}/Course/GetLectores").Result)
			        {
			            if (response.IsSuccessStatusCode)
			            {
			                string apiResponse = response.Content.ReadAsStringAsync().Result;
							lectorReponse = JsonConvert.DeserializeObject<LectorListResponse>(apiResponse);
			            }
			            else
			            {
			                ViewBag.Message = lectorReponse.message;
			                return View();
			            }
			        }
			    }
			}
			catch (Exception ex)
			{
			    this.logger.LogError("Error obteniendo los lectores", ex.ToString());
			    return View();
			}


			return View(lectorReponse.data);
		}

		public ActionResult Details(int id)
		{
			LectorDetailResponse lectorDetailResponse = this.lectorApiService.GetLector(id);


			try
			{
			    using (var httpClient = this.httpClientFactory.CreateClient())
			    {
			        using (var response = httpClient.GetAsync($"{this.baseUrl}/Course/GetLector?id={ id }").Result)
			        {
			            if (response.IsSuccessStatusCode)
			            {
			                string apiResponse = response.Content.ReadAsStringAsync().Result;
							lectorDetailResponse = JsonConvert.DeserializeObject<LectorDetailResponse>(apiResponse);
			            }
			            else
			            {
			                ViewBag.Message = lectorDetailResponse.message;
			                return View();
			            }
			        }
			    }
			}
			catch (Exception ex)
			{

			    this.logger.LogError("Error obteniendo los lectores", ex.ToString());
			    return View();
			}

			return View(lectorDetailResponse.data);
		}

		public ActionResult Create()
		{
			return View();
		}


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


		public ActionResult Edit(int id)
		{
			LectorDetailResponse lectorDetailResponse = new LectorDetailResponse();

			try
			{
			    using (var httpClient = this.httpClientFactory.CreateClient())
			    {
			        using (var response = httpClient.GetAsync($"{this.baseUrl}/Course/GetLector?id={id}").Result)
			        {
			            if (response.IsSuccessStatusCode)
			            {
			                string apiResponse = response.Content.ReadAsStringAsync().Result;
							lectorDetailResponse = JsonConvert.DeserializeObject<LectorDetailResponse>(apiResponse);
			            }
			            else
			            {
			                // realizar x logica //
		                    ViewBag.Message = lectorDetailResponse.message;
			                return View();
			            }
			        }
			    }
			}
		    catch (Exception ex)
			{

			    this.logger.LogError("Error obteniendo los cursos", ex.ToString());
			    return View();
			}

			return View(lectorDetailResponse.data);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
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

	}
}