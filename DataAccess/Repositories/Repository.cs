using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext Context;

        public Repository(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException();
        }

        public void Create(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Delete(Guid id)
        {
            var entity = GetAll().FirstOrDefault(x => x.Id == id);
            Context.Set<T>().Remove(entity);
        }

        public ICollection<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return Context.Set<T>().Find(id);
        }

        public T GetByFilter(Expression<Func<T, bool>> filter)
        {
            return Context.Set<T>().SingleOrDefault(filter);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}
