using Api.Views;
using Domain.Entities;
using Domain.UseCase.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        private ICoreRepositoryAsync<Note> _noteRepository;

        public NoteController(ICoreRepositoryAsync<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        [HttpPost()]
        [Authorize]
        public async Task<ActionResult> NotePost(NoteView aNote)
        {
            ArgumentNullException.ThrowIfNull(aNote);

            string? userId = User.FindFirstValue("UserId");
            if (userId == null) return Unauthorized();

            string? groupId = User.FindFirstValue("GroupId");
            if (groupId == null) return Unauthorized();

            var note = new Note
            {
                Title = aNote.Title,
                Content = aNote.Content,
                UserId = Guid.Parse(userId),
                GroupId = Guid.Parse(groupId)
            };

            var result = await _noteRepository.AddAsync(note);
            await _noteRepository.SaveChangesAsync();
            if (result.Succeeded) return Ok();
            return BadRequest(result.Errors);
        }

        [HttpGet()]
        [Authorize]
        public async Task<ActionResult> GetNote()
        {
            if (string.IsNullOrEmpty(User.FindFirstValue("GroupId")))
                return Unauthorized("User not subscribe group");
            return Ok(await _noteRepository.GetAllAsync());
        }

    }
}
