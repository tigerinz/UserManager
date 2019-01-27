using System;
using System.Collections.Generic;
using System.Text;

namespace UserRoleManager_Core.Infrastructure.Repository
{
    public interface IRepository<T>
    {
        List<T> GetAll();
    }
}
