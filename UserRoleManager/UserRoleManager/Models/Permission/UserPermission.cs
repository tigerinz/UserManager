using System;
using System.Collections.Generic;
using System.Text;

namespace UserRoleManager_Core.Models.Permission
{
    public class UserPermission
    {
        public Guid Id { get; set; }
        public string UserCode { get; set; }
        public string Url { get; set; }
    }
}
