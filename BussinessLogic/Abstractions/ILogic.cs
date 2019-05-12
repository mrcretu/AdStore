using Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BussinessLogic.Abstractions
{
    public interface ILogic<TEntity> where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity);

        void Delete(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity Find(TEntity entity);

        ICollection<TEntity> GetAll();

        TEntity GetByFilter(Expression<Func<TEntity, bool>> filter);
    }
}
