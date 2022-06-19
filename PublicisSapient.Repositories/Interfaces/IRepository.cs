using PublicisSapient.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PublicisSapient.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        bool Insert(TEntity entity);
        bool Update(TEntity entity);
        List<TEntity> GetAll();
        TEntity GetById(int id);
        List<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        bool Delete(int id);
        bool Delete(TEntity entity);
        void SaveChanges();
    }
}
