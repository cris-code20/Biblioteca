using Biblioteca.Infrestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infrestructure.Core
{
    internal class BaseRepository<TEntity> : LectorRepositories<TEntity> where TEntity : class
    {
        void LectorRepositories<TEntity>.Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }
        
        bool LectorRepositories<TEntity>.Exists(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TEntity> LectorRepositories<TEntity>.GetEntities()
        {
            throw new NotImplementedException();
        }

        TEntity LectorRepositories<TEntity>.GetEntity(int entityid)
        {
            throw new NotImplementedException();
        }

        void LectorRepositories<TEntity>.Save(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void LectorRepositories<TEntity>.Save(TEntity[] entities)
        {
            throw new NotImplementedException();
        }

        void LectorRepositories<TEntity>.update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
