using MediatR;
using Models.Entities;

namespace API.Queries
{
    public record GetUsersQuery() : IRequest<IEnumerable<UserEntity>>;

}
