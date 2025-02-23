using Microsoft.AspNetCore.Mvc.Filters;

namespace Microwave.Presentation.API.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizeAttribute : Attribute, IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var filter = new CustomAuthorizeFilter();
            await filter.OnAuthorizationAsync(context);
        }
    }
}
