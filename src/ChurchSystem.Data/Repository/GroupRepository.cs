using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchSystem.Business.Interfaces;
using ChurchSystem.Business.Models;
using ChurchSystem.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ChurchSystem.Data.Repository
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(ChurchSystemDbContext context) : base(context) { }

        public async Task<Group> GetGroup(Guid id)
        {
            return await Db.Groups.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Group> GetGroupAsNoTracking(Guid id)
        {
            return await Db.Groups.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id);
        }

        public List<Group> GetGroups()
        {
            return Db.Groups.ToList();
        }

        public async Task<List<Group>> GetGroupsById(Guid[] groupsIds)
        {
            List<Group> groups = await Db.Groups.ToListAsync();

            if (groupsIds != null)
            {
                groups = groups.Where(g => groupsIds.Contains(g.Id)).ToList();
            }
            
            return groups;
        }
    }
}
