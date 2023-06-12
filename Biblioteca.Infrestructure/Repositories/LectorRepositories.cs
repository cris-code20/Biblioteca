using Biblioteca.Infrestructure.Context;
using Biblioteca.Infrestructure.Core;
using Biblioteca.Infrestructure.Exceptions;
using Biblioteca.Infrestructure.Interface;
using Biblioteca.Infrestructure.Module;
using Biblioteca.Domain.Entities;
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


        List<LectorModel> ILector.GetLector(int IdLector)
        {
            List<LectorModel> Lector = new List<LectorModel>();
            try
            {
                this.logger.LogInformation($"Pase poraqui: {IdLector}");

                Lector = (from pres in base.GetEntities()
                             join es in context.lector.ToList() on pres.IdLector equals es.IdLector
                          where pres.IdLector == IdLector
                          select new LectorModel()
                             {
                                 IdLector = pres.IdLector,
                                 Codigo = pres.Codigo,

                             }).ToList();
            }
            catch (Exception ex)
            {
                this.logger.LogError($"Error obteniedo los lectores: {ex.Message}", ex.ToString());
            }

            return Lector;
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