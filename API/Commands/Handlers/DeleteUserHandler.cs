using Infrastructure.Repositories;
using MediatR;

namespace API.Commands.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, UserEntity>
    {

        UserRepository _repo;

        public DeleteUserHandler(UserRepository repo)
        {
            _repo = repo;
        }
        public Task<UserEntity> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return _repo.Delete(_repo.GetById(request.id).Result);
        }
    }
}
