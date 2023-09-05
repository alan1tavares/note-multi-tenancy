using Api.JWT;
using Api.Views;
using Domain.Entities;
using Domain.UseCase.Account;
using Domain.UseCase.Repository;
using Infrastructure;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private IAccount _account;
        private ICoreRepositoryAsync<User> _repositoryUser;
        private IGroupUserRepository _groupUserRepository;

        public AccountController(IAccount account,
            ICoreRepositoryAsync<User> repositoryUser,
            IGroupUserRepository groupUserRepository
        )
        {
            _account = account;
            _repositoryUser = repositoryUser;
            _groupUserRepository = groupUserRepository;
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
                        token = JwtUtils.GenerateToken(new UserToken 
                        {
                            Email = user.Email,
                            Id = user.Id.ToString()
                        })
                    });
                }
            }
            return NotFound("User not found or password is worong");
        }

        
        [HttpPost("SubscribeGroup")]
        [Authorize]
        public async Task<ActionResult> SubscribeGroup(Guid groupId)
        {
            string? userId = User.FindFirstValue("UserId");
            if (userId == null) return Unauthorized();

            User? user = await _repositoryUser.GeyByIdAsync(Guid.Parse(userId));
            if (user == null) return Unauthorized();

            bool groupUserExist = await _groupUserRepository.ExistAsync(Guid.Parse(userId), groupId);
            if (!groupUserExist) return NotFound("Goup not found");
            
            var token = JwtUtils.GenerateToken(new UserToken
            {
                Email = user.Email,
                Id = user.Id.ToString(),
                GroupId = groupId.ToString()

            });
            return Ok(new {token = token});
        }
    }
}
