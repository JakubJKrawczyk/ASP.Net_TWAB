namespace API.Commands
{
    public record UpdateProductCommand(int id, string newName, double newPrice) : IRequest<ProductEntity>;

}
