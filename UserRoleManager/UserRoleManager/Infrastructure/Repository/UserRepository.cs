using System;
using System.Collections.Generic;
using System.Text;
using UserRoleManager.Models;

namespace UserRoleManager.Infrastructure.Repository
{
    public class UserRepository:IRepository<User>
    {
        public List<User> GetAll()
        {
            List<User> user = new List<User>();
            return user;
        }
    }
}
