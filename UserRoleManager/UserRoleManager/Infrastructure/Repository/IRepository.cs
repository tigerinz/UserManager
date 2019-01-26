using System;
using System.Collections.Generic;
using System.Text;

namespace UserRoleManager.Infrastructure.Repository
{
    public interface IRepository<T>
    {
        List<T> GetAll();
    }
}
