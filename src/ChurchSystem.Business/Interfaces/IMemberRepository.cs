using System;
using System.Threading.Tasks;
using ChurchSystem.Business.Models;

namespace ChurchSystem.Business.Interfaces
{
    public interface IMemberRepository : IRepository<Member>
    {
        Task<Member> GetMember(Guid id);
    }
}
