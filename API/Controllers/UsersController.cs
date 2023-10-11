using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {
        // GET
        private readonly UserRepository userRepository;

        public UsersController()
        {
            userRepository = new(new ShopContext());
        }
        [HttpGet(Name = "GetAllUsers")]
        public Task<IEnumerable<UserEntity>> GetAllUsers() => userRepository.GetAll();
    }

}