namespace Api.JWT
{
    public class UserToken
    {
        public required string Email { get; set; }
        public required string Id { get; set; }
        public string? GroupId { get; set; }
    }
}
