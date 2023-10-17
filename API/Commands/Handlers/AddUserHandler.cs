
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Commands.Handlers
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, UserEntity>
    {
        UserRepository _repo;
        public AddUserHandler(UserRepository repo)
        {
            _repo = repo;
        }
        public Task<UserEntity> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {

            return _repo.Add(new UserEntity() { Login = request.Login, Id = _repo.GetAll().Result.ToList().Max(x => x.Id) + 1 });
        }
    }
}
