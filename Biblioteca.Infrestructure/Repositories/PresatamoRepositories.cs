using Biblioteca.Domain.Entitis;
using Biblioteca.Infrestructure.Context;
using Biblioteca.Infrestructure.Core;
using Biblioteca.Infrestructure.Exceptiones;
using Biblioteca.Infrestructure.Interface;
using Biblioteca.Infrestructure.Module;
using Microsoft.Extensions.Logging;


namespace Biblioteca.Infrestructure.Repositories
{
    public class PresatamoRepositories : BaseRepository<Prestamo>, IprestamosRepository
    {

        readonly ILogger<PresatamoRepositories> logger;
        readonly BibliotecaContext context;

        public PresatamoRepositories(ILogger<PresatamoRepositories> logger, BibliotecaContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }


        List<prestamoModels> IprestamosRepository.GetPrestamos(int IdEstadoPrestamo)
        {
            List< prestamoModels > prestamos = new List<prestamoModels>();
            try
            {
                this.logger.LogInformation($"Pase poraqui: {IdEstadoPrestamo}");

                prestamos = (from pres in base.GetEntities()
                            join es in context.estado.ToList() on pres.IdEstadoPrestamo equals es.IdEstadoPrestamo
                             where pres.IdEstadoPrestamo == IdEstadoPrestamo
                             select new prestamoModels()
                             {
                                 IdPrestamo = pres.IdPrestamo,
                                 Codigo = pres.Codigo,
                                 IdEstadoPrestamo = es.IdEstadoPrestamo,

                             }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error obteniedo los prestamos: {ex.Message }", ex.ToString());
            }

            return prestamos;
        }

        public override void Add(Prestamo entity)
        {
            if (this.Exists(cd => cd.IdEstadoPrestamo == entity.IdEstadoPrestamo)) 
                throw new PrestamoException("YA solicioto un prestamo");
           


            base.SaveChanges();
        }

    
    }
}
