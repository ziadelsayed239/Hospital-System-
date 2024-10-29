using DataAccess.Contexts;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationContext context;
        public BaseRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }
        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }
        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }
        public void Delete(IEnumerable<T> entities)
        {
            context.Remove(entities);
            context.SaveChanges();
        }
    }
}
