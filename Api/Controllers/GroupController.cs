using Domain.Entities;
using Domain.UseCase.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private ICoreRepositoryAsync<GroupUser> _repositoryGroupUser;

        public GroupController(ICoreRepositoryAsync<GroupUser> repositoryGroupUser)
        {
            _repositoryGroupUser = repositoryGroupUser;
        }

        [Authorize]
        [HttpPost()]
        public async Task<ActionResult> PostGroup(string name)
        {
            string? userId = User.FindFirstValue("UserId");
            if (userId == null) return Unauthorized();

            var groupUser = new GroupUser
            {
                Group = new Group { Name = name },
                UserId = Guid.Parse(userId)
            };
            var result = await _repositoryGroupUser.AddAsync(groupUser);
            await _repositoryGroupUser.SaveChangesAsync();
            if (result.Succeeded) return Ok();
            return BadRequest(result.Errors);
        }
    }
}
