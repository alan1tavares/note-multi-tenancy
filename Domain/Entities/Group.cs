
namespace Domain.Entities
{
    public class Group
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public ICollection<User> Users { get; } = new List<User>();
        public ICollection<GroupUser> GroupUsers { get; } = new List<GroupUser>();
    }
}
