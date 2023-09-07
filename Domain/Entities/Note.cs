
namespace Domain.Entities
{
    public class Note : IEntity, IGroup
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid GroupId { get; set; }
        public Group Group { get; set; } = null!;
    }
}
