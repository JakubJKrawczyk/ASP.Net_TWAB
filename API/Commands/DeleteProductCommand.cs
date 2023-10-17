namespace API.Commands
{
    public record DeleteProductCommand(int id) : IRequest<ProductEntity>;


}
