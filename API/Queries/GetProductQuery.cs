using MediatR;
using Models.Entities;

namespace API.Queries
{
    public record GetProductQuery() : IRequest<IEnumerable<ProductEntity>>;
}
