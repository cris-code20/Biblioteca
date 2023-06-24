
using Biblioteca.Domain.Repository;
using Biblioteca.Infrestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Biblioteca.Infrestructure.Core
{
    public abstract class BaseRepository<TEntity> : IRepositoriobase<TEntity> where TEntity : class
    {

        private readonly BibliotecaContext context;
        private readonly DbSet<TEntity> myDbset;

        public BaseRepository(BibliotecaContext context)
    {
        this.context = context;
            var entities = this.context.Set<TEntity>();
            myDbset = entities;
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
            return myDbset.Find(id);
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
