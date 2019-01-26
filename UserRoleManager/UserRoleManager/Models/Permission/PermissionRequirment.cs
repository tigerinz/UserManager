using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using UserRoleManager.Infrastructure;
using UserRoleManager.Infrastructure.Repository;

namespace UserRoleManager.Models.Permission
{
   public class PermissionRequirment : IAuthorizationRequirement
    {
        public string deniedAction;
        public List<UserPermission> userPermissions;

        public PermissionRequirment(string deniedAction, IRepository<UserPermission> repository)
        {
            this.deniedAction = deniedAction;
            userPermissions = repository.GetAll();
        }
    }
}
