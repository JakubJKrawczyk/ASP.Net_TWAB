namespace API.Commands
{
    public record DeleteUserCommand(int id) : IRequest<UserEntity>;


}
