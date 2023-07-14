using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChurchSystem.Business.Models;

namespace ChurchSystem.Business.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> GetRole(Guid id);
        Task<Role> GetRoleAsNoTracking(Guid id);
        List<Role> GetRoles();
        Task<List<Role>> GetRolesById(Guid[] roleids);
    }
}
