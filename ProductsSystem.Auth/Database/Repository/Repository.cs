using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProductsSystem.Auth.Models;

namespace ProductsSystem.Auth.Database.Repository
{
    public class Repository<T> : IRepository<T> where T : CommonModel
    {
        private readonly AuthDbContext _context;
        private readonly DbSet<T> _set;

        public Repository(AuthDbContext context)
        {
            this._set = context.Set<T>();
            this._context = context;
        }

        public RepositoryOperationResult Delete(Guid id)
        {
            var toDelete = _set.FirstOrDefault(x => x.Id == id);
            if (toDelete == null)
            {
                return new RepositoryOperationResult(false, $"Entity with id {id} not exists");
            }

            _context.Remove(toDelete);
            return new RepositoryOperationResult();
        }

        public RepositoryOperationResult<List<T>> GetByExpression(Expression<Func<T, bool>> predicate)
        {
            var entities = _set.AsEnumerable().Where(x => predicate.Compile()(x)).ToList();
            return new RepositoryOperationResult<List<T>>(entities);
        }

        public RepositoryOperationResult<T> GetById(Guid id)
        {
            var entity = _set.AsEnumerable().FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return new RepositoryOperationResult<T>(null, false, $"Entity with id {id} not exists");
            }

            return new RepositoryOperationResult<T>(entity);
        }

        public RepositoryOperationResult<List<V>> GetByQuery<V>(Expression<Func<IEnumerable<T>, List<V>>> advancedQuery)
        {
            try
            {
                var entities = advancedQuery.Compile()(_set.AsEnumerable());
                return new RepositoryOperationResult<List<V>>(entities);
            }
            catch (Exception ex)
            {
                return new RepositoryOperationResult<List<V>>(null, false, ex.ToString());
            }
        }

        public RepositoryOperationResult<T> GetOneByExpression(Expression<Func<T, bool>> predicate)
        {
            var entity = _set.AsEnumerable().FirstOrDefault(x => predicate.Compile()(x));
            return new RepositoryOperationResult<T>(entity);
        }

        public RepositoryOperationResult<V> GetOneByQuery<V>(Expression<Func<IEnumerable<T>, V>> advancedQuery)
        {
            try
            {
                var entities = advancedQuery.Compile()(_set.AsEnumerable());
                return new RepositoryOperationResult<V>(entities);
            }
            catch (Exception ex)
            {
                return new RepositoryOperationResult<V>(default, false, ex.ToString());
            }
        }

        public RepositoryOperationResult Save(T entity)
        {
            var existed = _set.FirstOrDefault(x => x.Id == entity.Id);
            if (existed != null)
            {
                return new RepositoryOperationResult(false, $"Entity with id {entity.Id} already exists");
            }

            entity.Init();

            _set.Add(entity);
            _context.SaveChanges();
            return new RepositoryOperationResult();
        }

        public RepositoryOperationResult Update(Guid id, T updatedEntity)
        {
            var existed = _set.FirstOrDefault(x => x.Id == id);
            if (existed == null)
            {
                return new RepositoryOperationResult(false, $"Entity with id {id} not exists");
            }

            // enity mapper
            var entity = updatedEntity;
            entity.Id = id;

            _set.Update(entity);
            _context.SaveChanges();
            return new RepositoryOperationResult();
        }
    }
}