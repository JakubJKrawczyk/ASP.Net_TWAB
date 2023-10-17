namespace API.Commands
{
    public record UpdateUserCommand(int id, string newLogin) : IRequest<UserEntity>;

}
