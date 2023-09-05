
namespace Domain.Entities
{
    public class GroupUser : IEntity
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }
        public Group Group { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
