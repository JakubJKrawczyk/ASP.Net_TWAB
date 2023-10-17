


using Infrastructure.Repositories;

namespace API.Queries.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserEntity>>
    {
        private readonly UserRepository _repo;

        public GetUsersHandler(UserRepository repo)
        {
            _repo = repo;
        }
        public Task<IEnumerable<UserEntity>> Handle(GetUsersQuery request, CancellationToken cancellationToken) => _repo.GetAll();
    }
}
