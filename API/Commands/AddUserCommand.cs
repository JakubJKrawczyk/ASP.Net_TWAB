using System.Windows.Input;

namespace API.Commands
{
    public record AddUserCommand(string Login) : IRequest<UserEntity>;



}
