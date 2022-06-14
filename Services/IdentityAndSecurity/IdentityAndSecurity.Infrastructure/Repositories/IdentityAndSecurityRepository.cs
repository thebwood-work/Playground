using IdentityAndSecurity.Infrastructure.Entities;
using IdentityAndSecurity.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Playground.Infrastructure.Base.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAndSecurity.Infrastructure.Repositories
{
    public class IdentityAndSecurityRepository : PlaygroundRepository<IdentityAndSecurityRepository>, IIdentityAndSecurityRepository
    {
        private IdentityAndSecurityContext _context;

        public IdentityAndSecurityRepository(ILogger<IdentityAndSecurityRepository> logger, IdentityAndSecurityContext context) : base(logger)
        {
            _context = context;
        }
        public User GetUserByUserName(string userName) => _context.Users.Where(u => u.UserName == userName).FirstOrDefault();
        public UserLogin GetUserLoginByUserId(Guid? userId) => _context.UserLogins.Where(u => u.UserId == userId).FirstOrDefault();

        public void Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void SaveUserLogin(UserLogin userLogin)
        {
            if (userLogin == null) return;

            if (userLogin.Id == null)
                _context.UserLogins.Add(userLogin);
            else
                _context.UserLogins.Update(userLogin);
            _context.SaveChanges();

        }
        public List<UserRoleRoleName> GetRoleNamesByUserId(Guid? id)
        {
            var results = (from role in _context.Roles
                           join userRole in _context.UserRoles on role.Id equals userRole.RoleId
                           where (userRole.UserId == id)
                           select new UserRoleRoleName
                           {
                               RoleName = role.RoleName
                           }).ToList();
            return results;
        }

    }
}
