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


        public override void Add(Prestamo entity)
        {
            if (this.Exists(pres => pres.IdPrestamo == entity.IdPrestamo)) 
            {
                throw new PrestamoException("Ya existe este prestamo");
            }

            base.Add(entity);
            base.SaveChanges();
        }

        public override void update(Prestamo entity)
        {
            try
            {
                Prestamo prestamoToUpdate = this.GetEntity(entity.IdPrestamo);

                prestamoToUpdate.IdPrestamo = entity.IdPrestamo;
                prestamoToUpdate.Codigo = entity.Codigo;
                prestamoToUpdate.EstadoEntregado = entity.EstadoEntregado;
                prestamoToUpdate.EstadoRecibido = entity.EstadoRecibido;
                prestamoToUpdate.FechaCreacion = entity.FechaCreacion;
                prestamoToUpdate.FechaDevolucion = entity.FechaDevolucion;
                prestamoToUpdate.FechaConfirmacionDevolucion = entity.FechaConfirmacionDevolucion;

                this.context.Prestamos.Update(prestamoToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error no puedes actualizar el prestamo", ex.ToString());
            }
        }

        public override void remove(Prestamo entity)
        {
            try
            {
                Prestamo prestamoToRemove = this.GetEntity(entity.IdPrestamo);

                
            }
            catch (Exception ex) 
            {
                this.logger.LogError("Error no puedes Eliminar el prestamo", ex.ToString());

            }
        }

        public prestamoModels GetPrestamoById(int id)
        {
            prestamoModels prestamoModelss = new prestamoModels();

            try
            {
                Prestamo prestamo = this.GetEntity(id);

                prestamoModelss.IdPrestamo = prestamo.IdPrestamo;
                prestamoModelss.IdEstadoPrestamo = prestamo.IdPrestamo;
                prestamoModelss.Codigo = prestamo.Codigo;
                prestamoModelss.IdLibro = prestamo.IdLibro;
               
            }
            catch(Exception ex) 
            {
                this.logger.LogError("Error no puedes obtener el prestamo", ex.ToString());

            }

            return prestamoModelss;
        }

        public List<prestamoModels> GetPrestamos(int IdPrestamo)
        {
            List<prestamoModels> prestamos = new();

            try
            {
                prestamos = this.context.Prestamos
                    .Select(pre => new prestamoModels()
                    {
                        IdPrestamo = pre.IdPrestamo,
                        IdEstadoPrestamo = pre.IdEstadoPrestamo,
                        IdLibro = pre.IdLibro,
                        IdLector = pre.IdLector
                    }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error no puedes obtener el prestamo", ex.ToString());

            }

            return prestamos;
        }

       
    }
}
