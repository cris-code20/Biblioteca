using Biblioteca_web.Services;
using Newtonsoft.Json;
using Biblioteca.Application.Dtos.Lector;
using Biblioteca.Infrestructure.Module;
using Biblioteca_web.Controllers;
using Biblioteca_web.Models.Responses;
using System.Text;

namespace Biblioteca_web.Services
{
	public class LectorApiService : ILectorApiService
	{
		private readonly IHttpClientFactory httpClientFactory;
		private readonly IConfiguration configuration;
		private readonly ILogger<LectorApiService> logger;
		private string baseUrl = string.Empty;
		public LectorApiService(IHttpClientFactory httpClientFactory,
							   IConfiguration configuration,
							   ILogger<LectorApiService> logger)
		{
			this.httpClientFactory = httpClientFactory;
			this.configuration = configuration;
			this.logger = logger;
			this.baseUrl = configuration["ApiConfig:baseUrl"];
		}

		public LectorDetailResponse GetLector(int id)
		{
			LectorDetailResponse lectorDetailResponse = new LectorDetailResponse();


			try
			{
				using (var httpClient = this.httpClientFactory.CreateClient())
				{
					using (var response = httpClient.GetAsync($"{this.baseUrl}/Lector/GetLector?id={id}").Result)
					{
						if (response.IsSuccessStatusCode)
						{
							string apiResponse = response.Content.ReadAsStringAsync().Result;
							lectorDetailResponse = JsonConvert.DeserializeObject<LectorDetailResponse>(apiResponse);
						}
						else
						{
							lectorDetailResponse.success = false;
							lectorDetailResponse.message = "Error conectandose al api de lector";
						}
					}
				}
			}
			catch (Exception ex)
			{
				lectorDetailResponse.success = false;
				lectorDetailResponse.message = "Error obteniendo los lectores";
				this.logger.LogError($"{lectorDetailResponse.message}", ex.ToString());

			}
			return lectorDetailResponse;
		}

		public LectorListResponse GetLectores()
		{
			LectorListResponse lectorResponse = new LectorListResponse();

			try
			{
				using (var httpClient = this.httpClientFactory.CreateClient())
				{
					using (var response = httpClient.GetAsync($"{this.baseUrl}/Lector/GetLectores").Result)
					{
						if (response.IsSuccessStatusCode)
						{
							string apiResponse = response.Content.ReadAsStringAsync().Result;
							lectorResponse = JsonConvert.DeserializeObject<LectorListResponse>(apiResponse);
						}
						else
						{
							lectorResponse.success = false;
							lectorResponse.message = "Error conectandose al api de lector";

						}
					}
				}
			}
			catch (Exception ex)
			{
				lectorResponse.success = false;
				lectorResponse.message = "Error obteniendo los lectores";
				this.logger.LogError($"{lectorResponse.message}", ex.ToString());

			}
			return lectorResponse;
		}

		public LectorSaveResponse Save(LectorAddDto lectorAddDto)
		{
			LectorSaveResponse lectorSaveResponse = new LectorSaveResponse();

			try
			{
				using (var httpClient = this.httpClientFactory.CreateClient())
				{
					StringContent content = new StringContent(JsonConvert.SerializeObject(lectorAddDto), Encoding.UTF8, "application/json");


					using (var response = httpClient.PostAsync($"{this.baseUrl}/Lector/Save", content).Result)
					{
						if (response.IsSuccessStatusCode)
						{
							string apiResponse = response.Content.ReadAsStringAsync().Result;

							lectorSaveResponse = JsonConvert.DeserializeObject<LectorSaveResponse>(apiResponse);
						}
						else
						{

							lectorSaveResponse.success = false;
							lectorSaveResponse.message = "Error conectandose al api de lector";
						}
					}
				}
			}
			catch (Exception ex)
			{
				lectorSaveResponse.success = false;
				lectorSaveResponse.message = "Error guardando el lector.";
				this.logger.LogError($"{lectorSaveResponse.message}", ex.ToString());
			}
			return lectorSaveResponse;
		}

		public LectorUpdateResponse Update(LectorUpdateDto lectorUpdateDto)
		{
			LectorUpdateResponse lectorUpdateResponse = new LectorUpdateResponse();

			try
			{
				using (var httpClient = this.httpClientFactory.CreateClient())
				{
					using (var response = httpClient.GetAsync($"{this.baseUrl}/Lector/Update").Result)
					{
						if (response.IsSuccessStatusCode)
						{
							string apiResponse = response.Content.ReadAsStringAsync().Result;
							lectorUpdateResponse = JsonConvert.DeserializeObject<LectorUpdateResponse>(apiResponse);
						}
						else
						{
							lectorUpdateResponse.success = false;
							lectorUpdateResponse.message = "Error conectandose al api de lector";

						}
					}
				}
			}
			catch (Exception ex)
			{
				lectorUpdateResponse.success = false;
				lectorUpdateResponse.message = "Error obteniendo los lectores";
				this.logger.LogError($"{lectorUpdateResponse.message}", ex.ToString());

			}
			return lectorUpdateResponse;
		}
	}
}