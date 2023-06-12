using Biblioteca.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Biblioteca.Infrestructure.Context;


namespace Biblioteca.Infrestructure.Core
{
    public abstract class BaseReposiroty<TEntity> : Irepository<TEntity> where TEntity : class
    {
   
        private readonly  Bibliotecacontext Context;

            private readonly DbSet<TEntity> myDbs;

        public BaseReposiroty(Bibliotecacontext context)
        {
            this.Context=context;
            this.myDbs = this.Context.Set<TEntity>();

        }

        public void Add(TEntity entity)
        {
           this.myDbs.Add(entity);
        }

        public virtual void Add(TEntity[] entities)
        {
            this.myDbs.AddRange(entities);
        }

        public virtual  bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.myDbs.Any(filter);
        }

        public virtual  List<TEntity> GetEntities()
        {
            return this.myDbs.ToList();
        }

        public virtual  TEntity GetEntity(int id)
        {
            return myDbs.Find(id);
        }

        public virtual void remove(TEntity entity)
        {
            this.myDbs.Remove(entity);
        }

        public virtual void remove(TEntity[] entity)
        {
            this.myDbs.RemoveRange(entity);
        }

        public virtual void SaveChanges()
        {
            this.Context.SaveChange();
        }

        public virtual void update(TEntity entity)
        {
           this.myDbs.Update(entity);
        }

        public virtual void update(TEntity[] entity)
        {
            this.myDbs.UpdateRange(entity);
        }
    }
}
