using Microsoft.Extensions.DependencyInjection;
using Biblioteca.Application.Contract;
using Biblioteca.Application.Service;
using Biblioteca.Infrestructure.Interface;
using Biblioteca.Infrestructure.Repositories;


namespace Biblioteca.IOC.Dependencies
{
    public static class LectorDependency
    {
        public static void AddLectorDependency(this IServiceCollection services)
        {

            services.AddScoped<ILector, LectorRepositories>();
            services.AddTransient<ILectorService, LectorService>();

        }
    }
}