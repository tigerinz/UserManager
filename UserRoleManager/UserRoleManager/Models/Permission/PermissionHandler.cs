using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace UserRoleManager.Models.Permission
{
    public class PermissionHandler : AuthorizationHandler<PermissionRequirment>
    {
        /// <summary>
        /// 用户权限
        /// </summary>
        public List<UserPermission> userPermission { get; set; }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirment requirement)
        {
            //赋值用户权限
            userPermission = requirement.userPermissions;
            //从AuthorizationHandlerContext转成HttpContext，以便取出表求信息
            var httpContext = (context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext).HttpContext;
            //请求Url
            string queryPath = httpContext.Request.Path.Value.ToLower();
            //是否经过验证
            if (httpContext.User.Identity.IsAuthenticated)
            {
                if (userPermission.GroupBy(p => p.Url).Where(u => u.Key.ToLower() == queryPath).Count() > 0)
                {
                    //用户名
                    var userCode = httpContext.User.Claims.SingleOrDefault(s => s.Type == ClaimTypes.Sid).Value;
                    //权限
                    if (userPermission.Where(permission => permission.UserCode == userCode && permission.Url.ToLower() == queryPath).Count() > 0)
                    {
                        context.Succeed(requirement);
                    }
                    else
                    {//无权限跳转到拒绝页面
                        httpContext.Response.Redirect("/denied");
                    }
                }
                else
                {
                    context.Succeed(requirement);
                }
            }
            return Task.CompletedTask;
        }
    }
}
