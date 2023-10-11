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
        public void Add(ProductEntity entity)
        {
            _context.products.Add(entity);
            Save();
        }


        public void Delete(ProductEntity entity)
        {

            _context.products.Remove(entity);
            Save();
        }


        public async Task<IEnumerable<ProductEntity>> GetAll() => await Task.FromResult(_context.products);

        public ProductEntity GetById(int id) => _context.products.First(p => p.PId == id);

        public void Update(ProductEntity entity)
        {
            ProductEntity toEdit = _context.products.First(p => p.PId == entity.PId);
            Delete(toEdit);
            Add(entity);

        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public void Save() => _context.SaveChanges();
    }
}
