using System;
using System.Collections.Generic;
using System.Text;

namespace UserRoleManager_Core.Models.Permission
{
    public class RolePermission
    {
        public Guid Id { get; set; }
        public string RoleCode { get; set; }
        public string Url { get; set; }
    }
}
