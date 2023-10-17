using Infrastructure.Repositories;
using MediatR;

namespace API.Commands.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ProductEntity>
    {

        ProductRepository _repo;

        public DeleteProductHandler(ProductRepository repo)
        {
            _repo = repo;
        }
        public Task<ProductEntity> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return _repo.Delete(_repo.GetById(request.id).Result);
        }
    }
}
