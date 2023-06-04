using Biblioteca.Infrestructure.Context;
using Biblioteca.Infrestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Biblioteca.Infrestructure.Core
{
    internal class BaseRepository<TEntity> : PresatamoRepositories<TEntity> where TEntity : class
    {
        private readonly BibliotecaContext biblioteca; 
        private readonly DbSet<TEntity> entities;
        public BaseRepository(BibliotecaContext biblioteca) 
        {
            this.biblioteca = biblioteca;
            this.entities = this.biblioteca.Set<TEntity>();
        }
        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<TEntity, bool>> filter)
        {

            return this.entities.Any(filter);
        }

        public IEnumerable<TEntity> GetEntities()
        {
            throw new NotImplementedException();
        }

        public TEntity GetEntity(int entityid)
        {
            throw new NotImplementedException();
        }

        public void Save(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Save(TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        public void update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
