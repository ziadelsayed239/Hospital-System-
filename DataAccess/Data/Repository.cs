using Shared.Base;
using DataAccess.Contexts;

namespace DataAccess.Data
{
    public class Repository<T> : BaseRepository<T> where T : Entity
    {
        public Repository(ApplicationContext context) : base(context) { }

        public T GetById(int id)
        {
            var entity = context.Set<T>().FirstOrDefault(x => x.Id == id) as T;
            return entity;
        }
    }
}
