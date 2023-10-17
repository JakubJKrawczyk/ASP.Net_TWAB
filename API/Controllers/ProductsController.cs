using API;
using API.Commands;
using API.Queries;
using Infrastructure.Context;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;

        public ProductsController(ShopContext context, IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet(Name = "GetAllProducts")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _mediator.Send(new GetProductsQuery());

            return Ok(products);
        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(string name, double price)
        {
            await _mediator.Send(new AddProductCommand(name, price));
            return Ok(new ProductEntity() { Name = name, Price = price });
        }
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(int id, string newName, double newPrice)
        {

            await _mediator.Send(new UpdateProductCommand(id, newName, newPrice));
            return Ok(new ProductEntity() { PId = id, Price = newPrice, Name = newName });

        }
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return Ok(new ProductEntity() { Name = "Done", Price = 0, PId = id });
        }

    }

}