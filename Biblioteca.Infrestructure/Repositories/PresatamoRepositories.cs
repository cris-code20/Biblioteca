using Biblioteca.Domain.Entitis;
using Biblioteca.Infrestructure.Context;
using Biblioteca.Infrestructure.Core;
using Biblioteca.Infrestructure.Exceptiones;
using Biblioteca.Infrestructure.Interface;
using Biblioteca.Infrestructure.Module;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Biblioteca.Infrestructure.Repositories
{
    public class PresatamoRepositories : BaseRepository<Prestamo>, IprestamosRepository
    {

        public ILogger<PresatamoRepositories> logger { get; private set; }
        public BibliotecaContext context { get; }

        public PresatamoRepositories(ILogger<PresatamoRepositories> logger, BibliotecaContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }


        List<prestamoModels> IprestamosRepository.GetPrestamos(int IdPrestamo)
        {
            List< prestamoModels > prestamos = new List<prestamoModels>();
            try
            {
                this.logger.LogInformation($"Pase poraqui: {IdPrestamo}");

                var query = select new prestamoModels()
                {
                    IdPrestamo = IdPrestamo,
                    Codigo = Codigo
                };
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error obteniedo los prestamos: {ex.Message }", ex.ToString());
            }
        }

        public override void Add(Prestamo entity)
        {
            if (this.Exists(cd => cd.Idprestamo == entity.IdPrestamo)) 
            {
                throw new PrestamoException("");
            }


            base.SaveChanges();
        }

    
    }
}
