using ChurchSystem.Business.Models;
using System;

namespace ChurchSystem.App.ViewsModels
{
    public class MemberGroupViewModel
    {
        public MemberGroupViewModel() { }

        public MemberGroupViewModel(MemberGroup memberGroup)
        {
            Id = memberGroup.Id;
            MemberId = memberGroup.MemberId;
            GroupId = memberGroup.GroupId;
        }

        public Guid Id { get; set; }

        public Guid MemberId { get; set; }

        public Guid GroupId { get; set; }
    }
}
