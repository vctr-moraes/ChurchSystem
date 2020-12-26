using System;
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
                .Include("MemberGroups.Group")
                .Include("MemberRoles.Role")
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
