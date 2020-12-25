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
            return await Db.Groups.Include(g => g.Members).FirstOrDefaultAsync(g => g.Id == id);
        }

        public List<Group> GetGroups()
        {
            return Db.Groups.ToList();
        }
    }
}
