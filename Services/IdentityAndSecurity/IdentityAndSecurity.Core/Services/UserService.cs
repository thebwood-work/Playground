using AutoMapper;
using IdentityAndSecurity.Core.Models;
using IdentityAndSecurity.Core.Services.Interfaces;
using IdentityAndSecurity.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Playground.Core.Base.Services;

namespace IdentityAndSecurity.Core.Services
{
    public class UserService : PlaygroundService<UserService>, IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IIdentityAndSecurityRepository _respository;
        private readonly IMapper _mapper;

        public UserService(ILogger<UserService> logger, IConfiguration configuration, IIdentityAndSecurityRepository respository, IMapper mapper) : base(logger)
        {
            _respository = respository ?? throw new ArgumentNullException();
            _configuration = configuration ?? throw new ArgumentNullException();
            _mapper = mapper ?? throw new ArgumentNullException();
        }

        public List<UserModel> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
