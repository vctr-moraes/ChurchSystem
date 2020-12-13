using ChurchSystem.Business.Interfaces;
using ChurchSystem.Business.Models;
using ChurchSystem.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChurchSystem.Data.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(ChurchSystemDbContext context) : base(context) { }
    }
}
