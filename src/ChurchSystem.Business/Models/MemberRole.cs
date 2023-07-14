using System;

namespace ChurchSystem.Business.Models
{
    public class MemberRole : Entity
    {
        public MemberRole() { }

        public MemberRole(Role role, Member member)
        {
            Role = role;
            RoleId = role.Id;
            Member = member;
            MemberId = member.Id;
        }

        public Guid MemberId { get; set; }
        public Guid RoleId { get; set; }

        /* EF Relations */
        public Member Member { get; set; }
        public Role Role { get; set; }
    }
}
