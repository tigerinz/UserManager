using System;
using System.Collections.Generic;
using System.Text;
using UserRoleManager_Core.Models.Permission;

namespace UserRoleManager_Core.Infrastructure.Repository
{
   public class UserPermissionRepository : IRepository<UserPermission>
    {

        public List<UserPermission> GetAll()
        {
            List<UserPermission> userPsermission = new List<UserPermission>();
            return userPsermission;
        }
    }
}
