namespace Infrastructure.Repositories
{
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public T GetById(int id);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}
