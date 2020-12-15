using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProductSystem.Management.Models;

namespace ProductSystem.Management.Database.Repository
{
    public interface IRepository<T> where T : CommonModel
    {
        public DbSet<T> DataSet { get; }
        RepositoryOperationResult<T> GetById(Guid id);
        RepositoryOperationResult<List<T>> GetByExpression(Expression<Func<T, bool>> predicate);
        RepositoryOperationResult<T> GetOneByExpression(Expression<Func<T, bool>> predicate);
        RepositoryOperationResult<List<V>> GetByQuery<V>(Expression<Func<IEnumerable<T>, List<V>>> advancedQuery);
        RepositoryOperationResult<V> GetOneByQuery<V>(Expression<Func<IEnumerable<T>, V>> advancedQuery);
        RepositoryOperationResult Save(T entity);
        RepositoryOperationResult Update(Guid id, T updatedEntity);
        RepositoryOperationResult Delete(Guid id); 
    }
}