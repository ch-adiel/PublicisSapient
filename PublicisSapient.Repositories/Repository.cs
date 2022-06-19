using Microsoft.EntityFrameworkCore;
using PublicisSapient.Models;
using PublicisSapient.Repositories.Context;
using PublicisSapient.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PublicisSapient.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly PublicisSapientContext _context;
        protected DbSet<TEntity> _entities;

        public Repository(PublicisSapientContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public bool Delete(int id)
        {
            var entity = _entities.Find(id);

            if (entity == null)
                return false;

            _entities.Remove(entity);
            SaveChanges();
            return true;
        }

        public bool Delete(TEntity entity)
        {
            if (entity == null)
                return false;

            _entities.Remove(entity);
            SaveChanges();
            return true;
        }

        public List<TEntity> GetAll()
        {
            return _entities.AsEnumerable().ToList();
        }

        public List<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate).ToList();
        }

        public TEntity GetById(int id)
        {
            var entity = _entities.Find(id);

            return entity;
        }

        public bool Insert(TEntity entity)
        {
            if (entity == null)
                return false;

            _entities.Add(entity);
            SaveChanges();
            return true;
        }

        public bool Update(TEntity entity)
        {
            if (entity == null)
                return false;

            _context.Entry(entity).State = EntityState.Modified;

            SaveChanges();
            return true;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
