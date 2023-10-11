using API;
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
        private readonly ProductRepository productRepository;

        public ProductsController()
        {
            productRepository = new(new ShopContext());
        }
        [HttpGet(Name = "GetAllProducts")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _mediator.Send(new GetProductQuery());

            return Ok(products);
        }


    }
}
