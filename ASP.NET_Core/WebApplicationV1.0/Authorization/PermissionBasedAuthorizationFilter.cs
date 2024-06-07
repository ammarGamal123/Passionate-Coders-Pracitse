using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using WebApplicationV1._0.Data;

namespace WebApplicationV1._0.Authorization
{
    public class PermissionBasedAuthorizationFilter(ApplicationDbContext dbContext) : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var attribute = (CheckPermissionAttribute)context.ActionDescriptor.EndpointMetadata
                .FirstOrDefault(x => x is CheckPermissionAttribute);

            if (attribute != null)
            {
                var claimIdentity = context.HttpContext.User.Identity as ClaimsIdentity;
                if (claimIdentity == null || !claimIdentity.IsAuthenticated)
                {
                    context.Result = new ForbidResult();
                }
                else
                {

                    var userId = int.Parse(claimIdentity.FindFirst
                        (ClaimTypes.NameIdentifier).Value);

                    var hasPermissions = dbContext.Set<UserPermission>()
                        .Any(x => x.UserId == userId &&
                        x.PermissionId == attribute.Permission);

                    if (!hasPermissions)
                    {
                        context.Result = new ForbidResult();
                    }

                }
            }
        }
    }
}
