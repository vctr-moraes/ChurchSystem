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
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(ChurchSystemDbContext context) : base(context) { }

        public async Task<Member> GetMember(Guid id)
        {
            return await Db.Members
                .Include(m => m.MemberGroups)
                .Include("MemberGroups.Group")
                .Include(m => m.MemberRoles)
                .Include("MemberRoles.Role")
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Member> GetMemberAsNoTracking(Guid id)
        {
            return await Db.Members.AsNoTracking()
                .Include(m => m.MemberGroups)
                .Include("MemberGroups.Group")
                .Include(m => m.MemberRoles)
                .Include("MemberRoles.Role")
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public List<Member> GetMembers()
        {
            return Db.Members.ToList();
        }
    }
}
