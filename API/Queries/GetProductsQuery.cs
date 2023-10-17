using MediatR;
using Models.Entities;

namespace API.Queries
{
    public record GetProductsQuery() : IRequest<IEnumerable<ProductEntity>>;
}
