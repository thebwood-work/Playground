using IdentityAndSecurity.Core.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Playground.Core.Base.Services;

namespace IdentityAndSecurity.Core.Services
{
    public class AuthorizationService : PlaygroundService<AuthorizationService>, IAuthorizationService
    {
        public AuthorizationService(ILogger<AuthorizationService> logger) : base(logger)
        {
        }
    }
}
