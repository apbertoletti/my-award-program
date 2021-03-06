using MyAwardProgram.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyAwardProgram.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        TEntity Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(int id);
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
