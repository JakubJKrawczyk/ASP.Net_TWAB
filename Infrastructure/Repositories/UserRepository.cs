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

        public async Task<UserEntity> Add(UserEntity entity) => await Task.Run(() =>
        {
            _context.Users.Add(entity);

            Save();
            return entity;
        });
        public async Task<UserEntity> Delete(UserEntity entity) => await Task.Run(() =>
        {
            _context.Users.Remove(entity);
            Save();
            return entity;
        });
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<UserEntity>> GetAll() => await Task.Run(() => _context.Users.ToList());

        public async Task<UserEntity> GetById(int id) => await Task.Run(() => _context.Users.First(x => x.Id == id));

        public async Task<UserEntity> Update(UserEntity entity) => await Task.Run(async () =>
        {
            UserEntity toEdit = _context.Users.FirstOrDefault(x => x.Id == entity.Id);
            if (toEdit != null)
            {
                await Delete(toEdit);
                await Add(entity);
            }


            return entity;
        });
        public void Save() => _context.SaveChanges();


    }
}
