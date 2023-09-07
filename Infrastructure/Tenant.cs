using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Domain.UseCase;

namespace Infrastructure
{
    public class Tenant : ITenant
    {
        private IHttpContextAccessor _httpContext;

        public Tenant(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor;
        }

        public Guid? Group
        {
            get
            {
                var groupId = _httpContext.HttpContext.User.FindFirstValue("GroupId");
                Guid? groupIdGuid = null;
                if (!string.IsNullOrEmpty(groupId))
                {
                    groupIdGuid = Guid.Parse(groupId);
                }
                return groupIdGuid;
            }
        }
    }
}
