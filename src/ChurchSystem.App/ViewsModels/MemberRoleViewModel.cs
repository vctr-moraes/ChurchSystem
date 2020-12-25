using ChurchSystem.Business.Models;
using System;

namespace ChurchSystem.App.ViewsModels
{
    public class MemberRoleViewModel
    {
        public MemberRoleViewModel() { }

        public MemberRoleViewModel(MemberRole memberRole)
        {
            Id = memberRole.Id;
            MemberId = memberRole.MemberId;
            RoleId = memberRole.RoleId;
        }

        public Guid Id { get; set; }

        public Guid MemberId { get; set; }

        public Guid RoleId { get; set; }
    }
}
