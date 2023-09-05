
namespace Domain.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public ICollection<Group> Groups { get; } = new List<Group>();
        public ICollection<GroupUser> GroupUsers = new List<GroupUser>();
    }
}
