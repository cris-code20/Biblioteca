using Biblioteca.Infrestructure.Entitis;
using System;
using System.Linq.Expressions;

namespace Biblioteca.Infrestructure.Repositories
{
    public interface  PresatamoRepositories<TEntity> where TEntity : class
    {
        void Save(TEntity entity);
        void Save(TEntity[] entities);
        void update(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetEntity(int entityid);
        bool Exists(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> GetEntities();

    }
}
