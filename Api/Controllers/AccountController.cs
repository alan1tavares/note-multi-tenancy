using Api.JWT;
using Api.Views;
using Domain.Entities;
using Domain.UseCase.Account;
using Domain.UseCase.Repository;
using Infrastructure;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private IAccount _account;

        public AccountController(IAccount account)
        {
            _account = account;
        }

        [AllowAnonymous]
        [HttpPost()]
        public async Task<ActionResult> PostAccount(UserAccount user)
        {
            var result = await _account.CreateAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult> PostLogin(string email, string password)
        {
            if (await _account.Autenticate(email, password))
            {
                var user = await _account.FindByEmailAsync(email);
                if (user != null)
                {
                    return Ok(new
                    {
                        token = JwtUtils.GenerateToken(user)
                    });
                }
            }
            return NotFound("User not found or password is worong");
        }
    }
}
