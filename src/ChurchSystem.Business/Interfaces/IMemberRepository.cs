using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChurchSystem.Business.Models;

namespace ChurchSystem.Business.Interfaces
{
    public interface IMemberRepository : IRepository<Member>
    {
        Task<Member> GetMember(Guid id);
        Task<Member> GetMemberAsNoTracking(Guid id);
        List<Member> GetMembers();
    }
}
