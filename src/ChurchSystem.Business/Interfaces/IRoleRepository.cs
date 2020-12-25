using System;
using System.Collections.Generic;
using System.Text;
using ChurchSystem.Business.Models;

namespace ChurchSystem.Business.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        List<Role> GetRoles();
    }
}
