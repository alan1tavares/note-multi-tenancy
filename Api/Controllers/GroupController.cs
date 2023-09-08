using Domain.Entities;
using Domain.UseCase.Repository;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private IGroupUserRepository _groupUserRespository;

        public GroupController(IGroupUserRepository repositoryGroupUser)
        {
            _groupUserRespository = repositoryGroupUser;
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
            var result = await _groupUserRespository.AddAsync(groupUser);
            await _groupUserRespository.SaveChangesAsync();
            if (result.Succeeded) return Ok();
            return BadRequest(result.Errors);
        }

        [HttpPost("Enter")]
        [Authorize]
        public async Task<ActionResult> Enter(string groupId)
        {
            string? userId = User.FindFirstValue("UserId");
            if (string.IsNullOrEmpty(userId)) return Unauthorized();

            var groupUserExist = (await _groupUserRespository.Get(e => 
                (e.UserId == Guid.Parse(userId)) && 
                (e.GroupId == Guid.Parse(groupId)))).FirstOrDefault();
            if (groupUserExist != null) return Ok();

            var groupUser = new GroupUser
            {
                GroupId = Guid.Parse(groupId),
                UserId = Guid.Parse(userId)
            };

            var result = await _groupUserRespository.AddAsync(groupUser);
            await _groupUserRespository.SaveChangesAsync();
            if (result.Succeeded) return Ok();
            return BadRequest(result.Errors);
        }
    }
}
