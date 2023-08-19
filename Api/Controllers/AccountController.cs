using Api.Views;
using Domain.Entities;
using Domain.UseCase.Repository;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private IRepository<User> _userRepository;

        public AccountController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult> PostAccount(UserView user)
        {
            var result = await _userRepository.SaveAsync(new User 
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            });

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }
    }
}
