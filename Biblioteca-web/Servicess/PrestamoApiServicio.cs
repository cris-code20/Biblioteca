using Biblioteca.Application.Dtos.Prestamo;
using Biblioteca_web.Models.Reponses;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Biblioteca_web.Servicess
{
    public class PrestamoApiServicio : IprestamoServicio

    {

        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<PrestamoApiServicio> logger;
        private string baseUrl = string.Empty;
        public PrestamoDetailResponse detailResponse;
        public PrestamoListReponse listReponse;
        public PrestamoUpdateResponse updateResponse;
        public PrestamoSaveReponse prestamoSave;

        public PrestamoApiServicio(IHttpClientFactory httpClientFactory,IConfiguration configuration,ILogger<PrestamoApiServicio> logger)
           {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = configuration["ApiConfig:baseUrl"];
           }



    public PrestamoDetailResponse GetCourse(int id)
        {
            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = httpClient.GetAsync($"{this.baseUrl}/Prestamo/GetPrestamo?id={id}").Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            detailResponse = JsonConvert.DeserializeObject<PrestamoDetailResponse>(apiResponse);
                        }
                      
                    }
                }
            }
            catch (Exception ex)
            {
                detailResponse.success = false;
                detailResponse.message = "Error obteniendo los cursos";
                this.logger.LogError($"{detailResponse.message}", ex.ToString());

            }
            return detailResponse;
        }

        public PrestamoListReponse GetCourses()
        {
            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    using (var response = httpClient.GetAsync($"{this.baseUrl}/Prestamo/GetPrestamo").Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;
                            listReponse = JsonConvert.DeserializeObject<PrestamoListReponse>(apiResponse);
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

        public PrestamoSaveReponse Save(PrestamoDto prestamoAdd)
        {
            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(prestamoAdd), Encoding.UTF8, "application/json");


                    using (var response = httpClient.PostAsync($"{this.baseUrl}/Course/Save", content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            prestamoSave = JsonConvert.DeserializeObject<PrestamoSaveReponse>(apiResponse);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                prestamoSave.success = false;
                prestamoSave.message = "Error guardando el curso.";
                this.logger.LogError($"{prestamoSave.message}", ex.ToString());
            }
            return prestamoSave;
        }

        public PrestamoUpdateResponse Update(PrestamoUpdateDto prestamoUpdate)
        {

            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(prestamoUpdate), Encoding.UTF8, "application/json");


                    using (var response = httpClient.PostAsync($"{this.baseUrl}/Course/Save", content).Result)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = response.Content.ReadAsStringAsync().Result;

                            updateResponse = JsonConvert.DeserializeObject<PrestamoUpdateResponse>(apiResponse);
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
