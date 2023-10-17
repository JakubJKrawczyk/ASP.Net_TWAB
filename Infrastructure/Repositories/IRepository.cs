using Models.Entities;

namespace Infrastructure.Repositories
{
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);
        public Task<T> Add(T entity);
        public Task<T> Update(T entity);
        public Task<T> Delete(T entity);
    }
}
