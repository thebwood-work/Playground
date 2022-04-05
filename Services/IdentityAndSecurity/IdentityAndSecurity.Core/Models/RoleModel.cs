using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAndSecurity.Core.Models
{
    public class RoleModel
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
