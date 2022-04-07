using System;
using System.Collections.Generic;

namespace IdentityAndSecurity.Infrastructure.Entities
{
    public partial class UserRole
    {
        public Guid? Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
