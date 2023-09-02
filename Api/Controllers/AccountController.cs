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
        private Account _account;

        public AccountController(Account account)
        {
            _account = account;
        }

        [AllowAnonymous]
        [HttpPost("Account")]
        public async Task<ActionResult> PostAccount(UserAccount user)
        {
            var result = await _account.CreateAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok();
        }
    }
}
