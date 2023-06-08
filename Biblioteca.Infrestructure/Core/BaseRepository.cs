using Biblioteca.Domain.Repository;
using Biblioteca.Infrestructure.Context;
using System.Linq.Expressions;


namespace Biblioteca.Infrestructure.Core
{
    public class BaseRepository<TEntity> : IRepositoriobase<TEntity> where TEntity : class
    {
        public BaseRepository(BibliotecaContext context)
        {
            Context = context;
        }

        public BibliotecaContext Context { get; }

        public object GetEntities()
        {
            throw new NotImplementedException();
        }

        void IRepositoriobase<TEntity>.Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        bool IRepositoriobase<TEntity>.Exists(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TEntity> IRepositoriobase<TEntity>.GetEntities()
        {
            throw new NotImplementedException();
        }

        TEntity IRepositoriobase<TEntity>.GetEntity(int entityid)
        {
            throw new NotImplementedException();
        }

         void IRepositoriobase<TEntity>.Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void IRepositoriobase<TEntity>.Add(TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        void IRepositoriobase<TEntity>.update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
