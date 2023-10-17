
using Infrastructure.Repositories;

namespace API.Commands.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductEntity>
    {
        ProductRepository _repo;

        public UpdateProductHandler(ProductRepository repo)
        {
            _repo = repo;
        }

        public Task<ProductEntity> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return _repo.Update(new ProductEntity() { Name = request.newName, Price = request.newPrice, PId = request.id });
        }
    }
}
