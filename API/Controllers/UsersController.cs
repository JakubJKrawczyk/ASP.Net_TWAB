using API.Commands;
using API.Queries;
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
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            userRepository = new(new ShopContext());
            _mediator = mediator;
        }
        [HttpGet(Name = "Users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _mediator.Send(new GetUsersQuery());
            return Ok(users);
        }

        [HttpPost("User")]
        public async Task<IActionResult> AddUser(string login)
        {
            await _mediator.Send(new AddUserCommand(login));
            return Ok(new UserEntity() { Login = login });
        }
        [HttpPut("User")]
        public async Task<IActionResult> UpdateUser(int id, string newlogin)
        {

            await _mediator.Send(new UpdateUserCommand(id, newlogin));
            return Ok(new UserEntity() { Login = newlogin });

        }
        [HttpDelete("User")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return Ok(new UserEntity() { Login = "Done", Id = id });
        }
    }

}