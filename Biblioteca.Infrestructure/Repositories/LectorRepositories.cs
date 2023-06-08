using Biblioteca.Domain.Entities;
using Biblioteca.Infrestructure.Context;
using Biblioteca.Infrestructure.Core;
using Biblioteca.Infrestructure.Exceptions;
using Biblioteca.Infrestructure.Interface;
using Biblioteca.Infrestructure.Module;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Biblioteca.Infrestructure.Repositories
{
    public class LectorRepositories : BaseRepository<Lector>, ILector
    {

        public ILogger<LectorRepositories> logger { get; private set; }
        public BibliotecaContext context { get; }

        public LectorRepositories(ILogger<LectorRepositories> logger, BibliotecaContext context) : base(context)
        {
            this.logger = logger;
            this.context = context;
        }


        List<LectorModels> ILector.GetPrestamos(int IdLector)
        {
            List<prestamoModels> prestamos = new List<LectorModel>();
            try
            {
                this.logger.LogInformation($"Pase poraqui: {IdLector}");

                var query = select new LectorModel()
                {
                    IdLector = IdLector,
                    Codigo = Codigo
                };
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error obteniedo los Lectores: {ex.Message}", ex.ToString());
            }
        }

        public override void Add(Lector entity)
        {
            if (this.Exists(cd => cd.IdLector == entity.IdLector))
            {
                throw new LectorException("");
            }


            base.SaveChanges();
        }


    }
}