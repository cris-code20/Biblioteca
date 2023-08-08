using Biblioteca.Application.Dtos.Lector;
using Biblioteca.Application.Dtos.Lector;
using Biblioteca_web.Models.Responses;
using Biblioteca_web.Services;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Biblioteca_web.Servicess
{
    public class LectorApiService : ILectorApiService

    {

        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<LectorApiService> logger;
        private string baseUrl = string.Empty;
        public LectorDetailResponse lectordetail;
        public LectorListResponse listReponse;
        public LectorUpdateResponse updateResponse;
        public LectorSaveResponse lectorSave;

        public LectorApiService(IHttpClientFactory httpClientFactory, IConfiguration configuration, ILogger<LectorApiService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = configuration["ApiConfig:baseUrl"];
        }



        public LectorDetailResponse GetLector(int id)
        {
            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = httpClient.GetAsync($"{this.baseUrl}/Lector/GetLector?id={id}").Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            lectordetail = JsonConvert.DeserializeObject<LectorDetailResponse>(apiResponse);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                lectordetail.success = false;
                lectordetail.message = "Error obteniendo los cursos";
                this.logger.LogError($"{lectordetail.message}", ex.ToString());

            }
            return lectordetail;
        }

        public LectorListResponse GetLectores()
        {
            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = httpClient.GetAsync($"{this.baseUrl}/Lector/GetLector").Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            listReponse = JsonConvert.DeserializeObject<LectorListResponse>(apiResponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listReponse.success = false;
                listReponse.message = "Error obteniendo los cursos";
                this.logger.LogError($"{listReponse.message}", ex.ToString());

            }
            return listReponse;
        }

        public LectorSaveResponse Save(LectorDto prestamoAdd)
        {
            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(prestamoAdd), Encoding.UTF8, "application/json");


                    using (var response = httpClient.PostAsync($"{this.baseUrl}/Lector/Save", content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            lectorSave = JsonConvert.DeserializeObject<LectorSaveResponse>(apiResponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lectorSave.success = false;
                lectorSave.message = "Error guardando el curso.";
                this.logger.LogError($"{lectorSave.message}", ex.ToString());
            }
            return lectorSave;
        }

        public LectorUpdateResponse Update(LectorUpdateDto lectorUpdate)
        {

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(lectorUpdate), Encoding.UTF8, "application/json");


                    using (var response = httpClient.PostAsync($"{this.baseUrl}/Lector/Save", content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            updateResponse = JsonConvert.DeserializeObject<LectorUpdateResponse>(apiResponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                updateResponse.success = false;
                updateResponse.message = "Error guardando el curso.";
                this.logger.LogError($"{updateResponse.message}", ex.ToString());
            }
            return updateResponse;

        }
    }
}