using System;
using System.Collections.Generic;
using System.Text;
using UserRoleManager_Core.Models;

namespace UserRoleManager_Core.Infrastructure.Repository
{
    public class UserRepository : IRepository<User>
    {
        public List<User> GetAll()
        {
            List<User> user = new List<User>();
            return user;
        }
    }
}
