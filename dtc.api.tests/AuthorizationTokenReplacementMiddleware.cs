using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace dtc.api.tests
{
    public class AuthorizationTokenReplacementMiddleware
    {
        private RequestDelegate next;

        public AuthorizationTokenReplacementMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await this.next(context);
        }
    }
}