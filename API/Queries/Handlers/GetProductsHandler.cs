using API.Queries;
using Infrastructure.Repositories;
using MediatR;
using Models.Entities;

namespace API.Queries.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductQuery, IEnumerable<ProductEntity>>
    {
        private readonly ProductRepository _repository;
        public GetProductsHandler(ProductRepository repo)
        {
            _repository = repo;
        }
        public Task<IEnumerable<ProductEntity>> Handle(GetProductQuery request, CancellationToken cancellationToken) => _repository.GetAll();
    }
}
