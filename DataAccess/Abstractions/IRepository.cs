using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Entities;

namespace DataAccess
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        void Create(TEntity entity);

        void Delete(Guid id);

        ICollection<TEntity> GetAll();

        TEntity GetById(Guid id);

        TEntity GetByFilter(Expression<Func<TEntity, bool>> filter);

        void Update(TEntity entity);

        void Commit();
    }
}
