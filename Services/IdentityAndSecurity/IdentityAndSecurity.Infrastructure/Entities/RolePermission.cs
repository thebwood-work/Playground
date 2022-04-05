using System;
using System.Collections.Generic;

namespace IdentityAndSecurity.Infrastructure.Entities
{
    public partial class RolePermission
    {
        public Guid Id { get; set; }
        public Guid RoleId { get; set; }
        public string Permission { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
