
using Infrastructure.Repositories;

namespace API.Commands.Handlers
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserEntity>
    {
        UserRepository _repo;

        public UpdateUserHandler(UserRepository repo)
        {
            _repo = repo;
        }

        public Task<UserEntity> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return _repo.Update(new UserEntity() { Login = request.newLogin, Id = request.id });
        }
    }
}
