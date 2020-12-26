using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChurchSystem.Business.Models;

namespace ChurchSystem.Business.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        List<Role> GetRoles();
        Task<List<Role>> GetRolesById(Guid[] roleids);
    }
}
