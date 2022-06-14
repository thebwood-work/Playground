using IdentityAndSecurity.Core.Models;
using IdentityAndSecurity.Core.Services.Interfaces;
using IdentityAndSecurity.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Playground.Core.Base.Services;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using IdentityAndSecurity.Infrastructure.Entities;
using AutoMapper;

namespace IdentityAndSecurity.Core.Services
{
    public class AuthenticationService : PlaygroundService<AuthenticationService>, IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly IIdentityAndSecurityRepository _respository;
        private readonly IMapper _mapper;

        public AuthenticationService(ILogger<AuthenticationService> logger, IConfiguration configuration, IIdentityAndSecurityRepository respository, IMapper mapper) : base(logger)
        {
            _respository = respository ?? throw new ArgumentNullException();
            _configuration = configuration ?? throw new ArgumentNullException();
            _mapper = mapper ?? throw new ArgumentNullException();
        }

        public UserRegisterResponseModel Register(UserRegisterModel request)
        {
            var registration = new UserRegisterResponseModel();

            var existingUser = _respository.GetUserByUserName(request.UserName);

            if (existingUser != null)
            {
                registration.ErrorMessages = new List<string>();
                registration.ErrorMessages.Add("User name already exists");

                return registration;
            }

            var user = new User();

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.UserName = request.UserName;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Email = request.Email;
            user.CreatedAt = DateTime.Now;
            user.CreatedBy = "system";
            user.IsDeleted = false;
            _respository.Register(user);
            return registration;
        }

        public UserLoginCredentialsResponseModel Login(UserLoginCredentialsModel request)
        {
            var response = new UserLoginCredentialsResponseModel();
            var login = new UserLoginCredentials(); 
            _mapper.Map(request, login);

            var user = _respository.GetUserByUserName(request.UserName);
            if (user == null || user.UserName != request.UserName)
            {
                response.ErrorMessages.Add("User not found.");
                return response;
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                response.ErrorMessages.Add("Password is incorrect");
                return response;
            }
            var roles = _respository.GetRoleNamesByUserId(user.Id);

            var token = CreateToken(user, roles);

            response.Token = token;
            return response;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
        private string CreateToken(User user, List<UserRoleRoleName> roles)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };
            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
            }
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration["Jwt:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"], 
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

    }
}
