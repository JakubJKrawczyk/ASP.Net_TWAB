using Infrastructure.Context;
using Models.Entities;

namespace Infrastructure.Repositories
{
    public class UserRepository : IRepository<UserEntity>, IDisposable
    {
        private readonly ShopContext _context;


        public UserRepository()
        {
            return;
        }
        public UserRepository(ShopContext context)
        {
            _context = context;
        }

        public void Add(UserEntity entity)
        {
            _context.users.Add(entity);

            Save();
        }
        public void Delete(UserEntity entity)
        {
            _context.users.Remove(entity);
            Save();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<UserEntity>> GetAll() => await Task.Run(() => _context.users.ToList());

        public UserEntity GetById(int id) => _context.users.First(x => x.Id == id);

        public void Update(UserEntity entity)
        {
            UserEntity toEdit = _context.users.FirstOrDefault(x => x.Id == entity.Id);
            Delete(toEdit);
            Add(entity);
        }
        public void Save() => _context.SaveChanges();
    }
}
