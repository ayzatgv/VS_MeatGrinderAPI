using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace MeatGrinderAPI.Helpers
{
    public class MyAuthorize : AuthorizeAttribute
    {
        private readonly string[] allowedroles;
        public MyAuthorize(params string[] roles)
        {
            this.allowedroles = roles;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string token = (actionContext.Request.Headers.Any(x => x.Key == "Authorization")) ? actionContext.Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value.SingleOrDefault().Replace("Bearer ", "") : "";

            if (actionContext == null || actionContext.Request == null || actionContext.Request.Headers.Authorization == null)
            {
                HandleUnauthorizedRequest(actionContext);
                return;
            }
            if (string.IsNullOrEmpty(actionContext.Request.Headers.Authorization.Parameter) || actionContext.Request.Headers.Authorization.Parameter == "undefined")
            {
                HandleUnauthorizedRequest(actionContext);
                return;
            }

            token = actionContext.Request.Headers.Authorization.Parameter;
            ClaimsPrincipal claimsPrincipal = MyToken.TokenDecryption(token);
            if (claimsPrincipal == null)
            {
                HandleUnauthorizedRequest(actionContext);
                return;
            }

            if (allowedroles != null && allowedroles.Length != 0)
            {
                bool access = false;

                foreach (string role in allowedroles)
                {
                    if (role == claimsPrincipal.Claims.First(c => c.Type == ClaimTypes.Role).Value)
                        access = true;
                }

                if (access == false)
                {
                    HandleUnauthorizedRequest(actionContext);
                    return;
                }
            }

        }
    }
}