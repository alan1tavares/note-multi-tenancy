using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public Guid UserId { get; set; }
        public required User User { get; set; }
    }
}
