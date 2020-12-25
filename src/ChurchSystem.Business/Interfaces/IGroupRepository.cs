using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChurchSystem.Business.Models;

namespace ChurchSystem.Business.Interfaces
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<Group> GetGroup(Guid id);
        List<Group> GetGroups();
    }
}
