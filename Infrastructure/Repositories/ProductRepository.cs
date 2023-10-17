using Infrastructure.Context;
using Models.Entities;


namespace Infrastructure.Repositories
{
    public class ProductRepository : IRepository<ProductEntity>
    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context)
        {
            _context = context;



        }
        public async Task<ProductEntity> Add(ProductEntity entity) => await Task.Run(() =>
        {
            _context.Products.Add(entity);
            Save();
            return entity;
        });


        public async Task<ProductEntity> Delete(ProductEntity entity) => await Task.Run(() =>
        {
            _context.Products.Remove(entity);
            Save();
            return entity;
        });


        public async Task<IEnumerable<ProductEntity>> GetAll() => await Task.FromResult(_context.Products);

        public async Task<ProductEntity> GetById(int id) => await Task.Run(() => _context.Products.First(p => p.PId == id));

        public async Task<ProductEntity> Update(ProductEntity entity) => await Task.Run(async () =>
        {
            ProductEntity toEdit = _context.Products.First(p => p.PId == entity.PId);
            await Delete(toEdit);
            await Add(entity);
            return entity;
        });
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public void Save() => _context.SaveChanges();
    }
}
