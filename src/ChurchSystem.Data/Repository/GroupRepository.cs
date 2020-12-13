using ChurchSystem.Business.Interfaces;
using ChurchSystem.Business.Models;
using ChurchSystem.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSystem.Data.Repository
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(ChurchSystemDbContext context) : base(context) { }
    }
}
