using AutoMapper;
using IdentityAndSecurity.Core.Models;
using IdentityAndSecurity.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAndSecurity.Core.Mapper
{
    public class IdentityAndSecurityProfile : Profile
    {
        public IdentityAndSecurityProfile()
        {
            CreateMap<UserLoginCredentialsModel, UserLoginCredentials>();
        }
    }
}
