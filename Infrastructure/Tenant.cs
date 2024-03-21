using Domain.UseCase;

namespace Infrastructure
{
    public class Tenant : ITenant
    {
        public Guid? Group { get; set; }
    }
}
