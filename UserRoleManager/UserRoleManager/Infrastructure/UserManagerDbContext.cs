using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserRoleManager_Core.Models;
using UserRoleManager_Core.Models.Permission;

namespace UserRoleManager_Core.Infrastructure
{
    public class UserManagerDbContext:DbContext
    {
        public UserManagerDbContext(DbContextOptions<UserManagerDbContext> options) : base(options)
        {
        }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\mssqllocaldb; Database =UserManager;Trusted_Connection=True;");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<UserPermission>().HasData(
        //    new List<UserPermission>()
        //    {
        //        new UserPermission { Url = "/", UserCode = "gsw" },
        //        new UserPermission { Url = "/home/permissionadd", UserCode = "gsw" },
        //        new UserPermission { Url = "/", UserCode = "aaa" },
        //        new UserPermission { Url = "/home/contact", UserCode = "aaa" }
        //    });

        //    modelBuilder.Entity<User>().HasData(new List<User>
        //    {
        //        new User { UserCode = "gsw", Password = "111111", Role =new Role{ RoleName="admin" },UserName="桂素伟",CreateDate=DateTime.Parse("2017-09-02")},
        //        new User { UserCode = "aaa", Password = "222222", Role =new Role{ RoleName= "system" },UserName="测试A" ,CreateDate=DateTime.Parse("2017-09-03")}
        //    });
         
            
        //    //base.OnModelCreating(modelBuilder);
        //}
    }
}
