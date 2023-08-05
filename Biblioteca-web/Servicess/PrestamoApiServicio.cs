using Biblioteca.Application.Dtos.Prestamo;
using Biblioteca_web.Models.Reponses;
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
        public PrestamoApiServicio(IHttpClientFactory httpClientFactory,IConfiguration configuration,ILogger<PrestamoApiServicio> logger)
           {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = configuration["ApiConfig:baseUrl"];
           }



    public PrestamoDetailResponse GetCourse(int id)
        {
            throw new NotImplementedException();
        }

        public PrestamoListReponse GetCourses()
        {
            throw new NotImplementedException();
        }

        public PrestamoSaveReponse Save(PrestamoDto prestamoAdd)
        {
            throw new NotImplementedException();
        }

        public PrestamoUpdateResponse Update(PrestamoUpdateDto prestamoUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
