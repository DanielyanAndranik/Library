using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Repository;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository repository;

        public UsersController(IUserRepository _repository)
        {
            repository = _repository;
        }

        //[Authorize(Policy = "Admin")]
        [HttpGet(Name = "GetUsers")]
        public async Task<IEnumerable<User>> Get()
        {
            var result = await repository.GetUsers();
            return result;
        }

        //[Authorize(Policy = "Approved")]
        [HttpGet("{id}", Name = "GetUserById")]
        public async Task<IActionResult> Get(int id)
        {
            if (User.FindFirst("role").Value != "admin")
            {
                if (User.FindFirst("user_id").Value != id.ToString())
                {
                    return new BadRequestResult();
                }
            }
            var result = await repository.GetUserById(id);
            return new ObjectResult(result);
        }

        //[HttpGet("{username}", Name = "GetUserByUsername")]
        //public async Task<IActionResult> Get(string username)
        //{
        //    var result = await repository.GetUserByUsername(username);
        //    return new ObjectResult(result);
        //}

        //[Authorize(Policy = "Guest")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            var result = await repository.AddUser(user);
            if (result == RepositoryResponses.Success)
            {
                return new OkResult();
            }
            else
            {
                return new BadRequestResult();
            }
        }

        //[Authorize(Policy = "Approved")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] User user)
        {
            if (User.FindFirst("role").Value != "admin")
            {
                if (User.FindFirst("user_id").Value != user.Id.ToString())
                {
                    return new BadRequestResult();
                }
            }
            var result = await repository.UpdateUser(user);
            return new ObjectResult(result);
        }

        //[Authorize(Policy = "Approved")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (User.FindFirst("role").Value != "admin")
            {
                if (User.FindFirst("user_id").Value != id.ToString())
                {
                    return new BadRequestResult();
                }
            }
            var result = await repository.DeleteUser(id);
            return new ObjectResult(result);
        }
    }
}
