using IdentityAndSecurity.Core.Services;
using IdentityAndSecurity.Core.Services.Interfaces;
using IdentityAndSecurity.Infrastructure.Repositories;
using IdentityAndSecurity.Infrastructure.Repositories.Interfaces;
using People.Core.Services;
using People.Core.Services.Interfaces;
using People.Infrastructure.Repositories;
using People.Infrastructure.Repositories.Interfaces;

namespace People.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureCors(this IServiceCollection services, IConfiguration configuration, string policyName)
        {
            services.AddCors(options =>
                options.AddPolicy(policyName,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .SetIsOriginAllowedToAllowWildcardSubdomains();
                    }
                )
            ); ;
        }

        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IPeopleRepository, PeopleRepository>();
            services.AddTransient<IPeopleService, PeopleService>();
        }
    }
}
