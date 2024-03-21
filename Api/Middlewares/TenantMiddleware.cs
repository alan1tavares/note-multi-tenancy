
using System.Security.Claims;
using Domain.UseCase;

namespace Api;

public class TenantMiddleware : IMiddleware
{
    ITenant _tenant;

    public TenantMiddleware(ITenant tenant)
    {
        _tenant = tenant;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var groupId = context.User.FindFirstValue("GroupId");
        Guid? groupIdGuid = null;
        if (!string.IsNullOrEmpty(groupId))
        {
            groupIdGuid = Guid.Parse(groupId);
        }
        _tenant.Group = groupIdGuid;

        await next(context);
    }
}
