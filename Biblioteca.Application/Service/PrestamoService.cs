using Biblioteca.Application.Contract;
using Biblioteca.Infrestructure.Repositories;
using Microsoft.Extensions.Logging;

namespace Biblioteca.Application.Service
{
    public class PrestamoService : IPrestamoService
    {
        private readonly IPrestamoService prestamoService;
        private readonly ILogger<PrestamoService> logger;

        public PrestamoService(PresatamoRepositories presatamoRepositories, ILogger<PrestamoService> logger)
        {
            this.presatamoRepositories = presatamoRepositories;
            this.logger = logger;
        }
    }
}
