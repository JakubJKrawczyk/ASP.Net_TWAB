using System.Windows.Input;

namespace API.Commands
{
    public record AddProductCommand(string Name, double Price) : IRequest<ProductEntity>;



}
