using System;
using System.Collections.Generic;
using System.Text;

namespace UserRoleManager_Core.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
    }
}
