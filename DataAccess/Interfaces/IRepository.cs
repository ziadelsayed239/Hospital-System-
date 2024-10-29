namespace DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        // basic CRUD ops
        IQueryable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
