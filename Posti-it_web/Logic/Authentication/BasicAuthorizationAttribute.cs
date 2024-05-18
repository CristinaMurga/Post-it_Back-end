using Microsoft.AspNetCore.Authorization;

namespace Posti_it_web.Logic.Authentication
{
    public class BasicAutorizationAttributes : AuthorizeAttribute
    {
        public BasicAutorizationAttributes()
        {
            Policy = "BasicAuthentication";
        }
    }
}
