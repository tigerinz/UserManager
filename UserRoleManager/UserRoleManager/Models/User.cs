using System;
using System.Collections.Generic;
using System.Text;

namespace UserRoleManager_Core.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
