using Biblioteca.Infrestructure.Context;
using Biblioteca.Infrestructure.Core;
using Biblioteca.Infrestructure.Entitis;
using Biblioteca.Infrestructure.Excepcion;
using Biblioteca.Infrestructure.Interface;
using Biblioteca.Infrestructure.Module;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infrestructure.Repositories
{


    public class libroRepositories : BaseReposiroty<Libro>, ILibroRepository
    {

        readonly ILogger<libroRepositories> logger;
        readonly Bibliotecacontext context;

        public libroRepositories(ILogger<libroRepositories> logger, Bibliotecacontext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }


        public override void Add(Libro entity)
        {
            if (!this.Exists(li => li.IdLibro == entity.IdLibro))
            {

                throw new LibroExcepcion("Ya existe este libro");
            }

            base.Add(entity);
            base.SaveChanges();

        }

        public override void update(Libro entity)
        {
            try
            {
                Libro libroToUpdate = this.GetEntity(entity.IdLibro);

                libroToUpdate.IdLibro = entity.IdLibro;
                libroToUpdate.Titulo = entity.Titulo;
                libroToUpdate.autor = entity.autor;
                libroToUpdate.Editorial = entity.Editorial;
                libroToUpdate.Ejemplares = entity.Ejemplares;

                this.context.Libro.Update(libroToUpdate);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error no puedes actualizar el libro", ex.ToString());
            }
        }

        public override void remove(Libro entity)
        {
            try
            {
                Libro LibroToRemove = this.GetEntity(entity.IdLibro);


            }
            catch (Exception ex)
            {
                this.logger.LogError("Error no puedes Eliminar el libro", ex.ToString());

            }
        }

        public LibroModels GetPrestamoById(int id)
        {
            LibroModels LibroModelss = new LibroModels();

            try
            {
                Libro Libro = this.GetEntity(id);




            }
            catch (Exception ex)
            {
                this.logger.LogError("Error no puedes obtener el libro", ex.ToString());

            }

            return LibroModelss;
        }

        public List<LibroModels> GetPrestamos(int IdLibro, object li)
        {
            List<LibroModels> Libro = new();

            try
            {
                Libro = this.context.Libro
                    .Select(pre => new LibroModels()
                    {
                        IdLibro = li.IdLibro,
                        Titulo = li.Titulo,
                        Autor = li.Autor,
                        Editorial = li.Editorial,
                        Ejemplares = li.Ejemplares,
                        Portadas = li.Portadas


                    }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError("Error no puedes obtener el Libro", ex.ToString());

            }

            return Libro;
        }

        public List<LibroModels> GetLibro(int IdLibro)
        {
            throw new NotImplementedException();
        }
    }
}
