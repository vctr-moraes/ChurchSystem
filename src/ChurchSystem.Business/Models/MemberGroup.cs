using System;

namespace ChurchSystem.Business.Models
{
    public class MemberGroup : Entity
    {
        public MemberGroup() { }

        public MemberGroup(Group group, Member member)
        {
            Group = group;
            GroupId = group.Id;
            Member = member;
            MemberId = member.Id;
        }

        public Guid MemberId { get; set; }
        public Guid GroupId { get; set; }

        /* EF Relations */
        public Member Member { get; set; }
        public Group Group { get; set; }
    }
}
