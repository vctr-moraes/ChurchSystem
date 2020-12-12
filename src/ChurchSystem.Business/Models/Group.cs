using System;
using System.Collections.Generic;

namespace ChurchSystem.Business.Models
{
    public class Group : Entity
    {
        public string Description { get; set; }

        /* EF Relations */
        public IEnumerable<MemberGroup> Members { get; set; }
    }
}
