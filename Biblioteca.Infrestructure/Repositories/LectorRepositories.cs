using Biblioteca.Domain.Repository;
using Biblioteca.Infrestructure.Context;
using Biblioteca.Infrestructure.Core;
using Biblioteca.Infrestructure.Entities;
using Biblioteca.Infrestructure.Exceptions;
using Biblioteca.Infrestructure.Interface;
using Biblioteca.Infrestructure.Module;
using Microsoft.Extensions.Logging;


namespace Biblioteca.Infrestructure.Repositories
{
    public class LectorRepositories : BaseRepository<Lector>, ILector
    {

        readonly ILogger<LectorRepositories> logger;
        readonly Bibliotecacontext context;

        public LectorRepositories(ILogger<LectorRepositories> logger, Bibliotecacontext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }


        public override void Add(Lector entity)
        {
            if (this.Exists(pres => pres.IdLector == entity.IdLector))
            {
                throw new LectorException("Ya existe este Lector");
            }

            base.Add(entity);
            base.SaveChanges();
        }

        public override void update(Lector entity)
        {
            try
            {
                Lector lectorToUpdate = this.GetEntity(entity.IdLector);

                lectorToUpdate.IdLector = entity.IdLector;
                lectorToUpdate.Codigo = entity.Codigo;
                lectorToUpdate.Nombre = entity.Nombre;
                lectorToUpdate.Apellido = entity.Apellido;
                lectorToUpdate.FechaCreacion = entity.FechaCreacion;
                lectorToUpdate.Correo = entity.Correo;
                lectorToUpdate.Clave = entity.Clave;
                lectorToUpdate.Estado = entity.Estado;

                this.context.Lectores.Update(lectorToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error no puedes actualizar el prestamo", ex.ToString());
            }
        }

        public override void remove(Lector entity)
        {
            try
            {
                Lector lectorToRemove = this.GetEntity(entity.IdLector);


            }
            catch (Exception ex)
            {
                this.logger.LogError("Error no puedes Eliminar el lector", ex.ToString());

            }
        }

        public LectorModel GetLectorById(int id)
        {
            LectorModel lectorModelss = new LectorModel();

            try
            {
                Lector lector = this.GetEntity(id);

                lectorModelss.IdLector = lector.IdLector;

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error no puedes obtener el lector", ex.ToString());

            }

            return lectorModelss;
        }
        public List<LectorModel> GetLectors()
        {
            List<LectorModel> lectors = new List<LectorModel>();

            try




            {
                lectors = this.context.Lectores.Select(cu => new LectorModel()
                          {
                              IdLector = cu.IdLector,
                              Nombre = cu.Nombre,
                              Apellido= cu.Apellido,
                              Correo = cu.Correo,
                          }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error no puedes obtener los lectores", ex.ToString());
            }

            return lectors;
        }

    }
}