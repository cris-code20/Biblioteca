using Biblioteca.Domain.Entitis;
using Biblioteca.Infrestructure.Context;
using Biblioteca.Infrestructure.Core;
using Biblioteca.Infrestructure.Exceptiones;
using Biblioteca.Infrestructure.Interface;
using Biblioteca.Infrestructure.Module;
using Microsoft.Extensions.Logging;
using System.Linq;


namespace Biblioteca.Infrestructure.Repositories
{
    public class PresatamoRepositories : BaseRepository<Prestamo>, IprestamosRepository
    {

        private readonly ILogger<PresatamoRepositories> logger;
        private readonly BibliotecaContext context;

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
                prestamoToUpdate.ModifyDate = entity.ModifyDate;
                prestamoToUpdate.Codigo = entity.Codigo;
                prestamoToUpdate.IdEstadoPrestamo  = entity.IdEstadoPrestamo;
                prestamoToUpdate.Usermod = entity.Usermod;
                

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
                
                prestamoToRemove.DeleteDate = entity.DeleteDate;
                prestamoToRemove.UserDelete = entity.UserDelete;
                prestamoToRemove.Deleted = entity.Deleted;



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
                prestamoModelss.IdLector = prestamo.IdLector;
                prestamoModelss.FechaDevolucion = prestamo.FechaConfirmacionDevolucion;
                prestamoModelss.FechaConfirmacionDevolucion = prestamo.FechaConfirmacionDevolucion;
                prestamoModelss.EstadoEntregado = prestamo.EstadoEntregado;
                prestamoModelss.EstadoRecibido = prestamo.EstadoRecibido;


            }
            catch(Exception ex) 
            {
                this.logger.LogError("Error no puedes obtener el prestamo1", ex.ToString());

            }

            return prestamoModelss;
        }

        public List<prestamoModels> GetPrestamos()
        {
            List<prestamoModels> prestamos = new List<prestamoModels>();

            try
            {
                prestamos = this.context.Prestamos
                                        .Select(pre => new prestamoModels()
                    {
                        IdPrestamo = pre.IdPrestamo,
                        Codigo = pre.Codigo,
                        IdEstadoPrestamo = pre.IdEstadoPrestamo,
                        IdLibro = pre.IdLibro,
                        IdLector = pre.IdLector,
                        FechaDevolucion = pre.FechaDevolucion,
                        FechaConfirmacionDevolucion = pre.FechaConfirmacionDevolucion,
                        EstadoEntregado = pre.EstadoEntregado,
                        EstadoRecibido = pre.EstadoRecibido

                    }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error no puedes obtener el prestamo2", ex.ToString());

            }

            return prestamos;
        }

       
    }
}
