using Biblioteca.Domain.Repository;
using Biblioteca.Infrestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;



namespace Biblioteca.Infrestructure.Core
{
    public abstract class BaseRepository<TEntity> : IRepositoryBaseLector<TEntity> where TEntity : class
    {

        private readonly Bibliotecacontext context;
        private readonly DbSet<TEntity> myDbset;

        public BaseRepository(Bibliotecacontext context)
        {
            this.context = context;
            this.myDbset = this.context.Set<TEntity>();
        }


        public virtual void Add(TEntity entity)
        {
            this.myDbset.Add(entity);
        }

        public virtual void Add(TEntity[] entities)
        {
            this.myDbset.AddRange(entities);
        }

        public virtual List<TEntity> GetEntities()
        {
            return this.myDbset.ToList();
        }

        public virtual TEntity GetEntity(int id)
        {
            return this.myDbset.Find(id);
        }

        public virtual void remove(TEntity entity)
        {
            this.myDbset.Remove(entity);
        }

        public virtual void remove(TEntity[] entities)
        {
            this.myDbset.RemoveRange(entities);
        }

        public virtual void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public virtual void update(TEntity entity)
        {
            this.myDbset.Update(entity);
        }

        public virtual void update(TEntity[] entities)
        {
            this.myDbset.UpdateRange(entities);
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.myDbset.Any(filter);
        }
    }
}