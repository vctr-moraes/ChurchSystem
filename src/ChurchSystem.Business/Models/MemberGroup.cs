using System;

namespace ChurchSystem.Business.Models
{
    public class MemberGroup : Entity
    {
        public Guid MemberId { get; set; }
        public Guid GroupId { get; set; }

        /* EF Relations */
        public Member Member { get; set; }
        public Group Group { get; set; }
    }
}
