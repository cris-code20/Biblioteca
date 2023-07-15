using System.Linq.Expressions;
namespace Biblioteca.Domain.Repository
{
    public interface IRepositoryBaseLector<TEntity> where TEntity : class
{
    void Add(TEntity entity);
    void Add(TEntity[] entity);
    void update(TEntity entity);
    void Delete(TEntity entity);
    TEntity GetEntity(int entityid);
    bool Exists(Expression<Func<TEntity, bool>> filter);
    IEnumerable<TEntity> GetEntities();

}
}