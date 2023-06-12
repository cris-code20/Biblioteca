
using System.Linq.Expressions;

namespace Biblioteca.Domain.Repositories
{
   
        public interface Irepository<TEntity> where TEntity : class
        {
        void Add(TEntity entity);
        void Add(TEntity[] entities);
        void update(TEntity entity);
        void update(TEntity[] entity);
        void remove(TEntity entity);
        void remove(TEntity[] entity);
        TEntity GetEntity(int id);
        List<TEntity> GetEntities();
        bool Exists(Expression<Func<TEntity, bool>> filter);

        void SaveChanges();

    }
    
}
