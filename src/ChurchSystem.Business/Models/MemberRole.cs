using System;

namespace ChurchSystem.Business.Models
{
    public class MemberRole : Entity
    {
        public Guid MemberId { get; set; }
        public Guid RoleId { get; set; }

        /* EF Relations */
        public Member Member { get; set; }
        public Role Role { get; set; }
    }
}
