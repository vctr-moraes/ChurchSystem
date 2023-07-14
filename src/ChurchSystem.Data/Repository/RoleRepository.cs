using ChurchSystem.Business.Interfaces;
using ChurchSystem.Business.Models;
using ChurchSystem.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurchSystem.Data.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(ChurchSystemDbContext context) : base(context) { }

        public async Task<Role> GetRole(Guid id)
        {
            return await Db.ListRoles.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Role> GetRoleAsNoTracking(Guid id)
        {
            return await Db.ListRoles.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        }

        public List<Role> GetRoles()
        {
            return Db.ListRoles.ToList();
        }

        public async Task<List<Role>> GetRolesById(Guid[] rolesids)
        {
            List<Role> roles = await Db.ListRoles.AsNoTracking().ToListAsync();

            if (rolesids != null)
            {
                roles = roles.Where(r => rolesids.Contains(r.Id)).ToList();
            }

            return roles;
        }
    }
}
