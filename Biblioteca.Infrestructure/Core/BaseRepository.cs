using Biblioteca.Infrestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infrestructure.Core
{
    internal class BaseReposiroty<TEntity> : LibroRepositories<TEntity> where TEntity : class
    {
        void LibroRepositories<TEntity>.Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        bool LibroRepositories<TEntity>.Exists(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TEntity> LibroRepositories<TEntity>.GetEntities()
        {
            throw new NotImplementedException();
        }

        TEntity LibroRepositories<TEntity>.GetEntity(int entityid)
        {
            throw new NotImplementedException();
        }

        void LibroRepositories<TEntity>.Save(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void LibroRepositories<TEntity>.Save(TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        void LibroRepositories<TEntity>.update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
