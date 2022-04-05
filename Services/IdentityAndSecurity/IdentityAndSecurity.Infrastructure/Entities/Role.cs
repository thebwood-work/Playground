using System;
using System.Collections.Generic;

namespace IdentityAndSecurity.Infrastructure.Entities
{
    public partial class Role
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
