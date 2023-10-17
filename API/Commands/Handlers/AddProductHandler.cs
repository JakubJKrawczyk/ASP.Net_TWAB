
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Commands.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, ProductEntity>
    {
        ProductRepository _repo;
        public AddProductHandler(ProductRepository repo)
        {
            _repo = repo;
        }
        public Task<ProductEntity> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {

            return _repo.Add(new ProductEntity() { Name = request.Name, Price = request.Price, PId = _repo.GetAll().Result.ToList().Max(x => x.PId) + 1 });
        }
    }
}
