using System;
using System.Collections.Generic;
using System.Text;
using UserRoleManager.Models.Permission;

namespace UserRoleManager.Infrastructure.Repository
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
