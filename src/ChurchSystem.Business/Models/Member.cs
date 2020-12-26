using System;
using System.Collections.Generic;
using System.Linq;

namespace ChurchSystem.Business.Models
{
    public class Member : Entity
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime? DateBirth { get; set; }
        public string Address { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Mailbox { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Baptized { get; set; }
        public bool Status { get; set; }
        public DateTime RegistrationDate { get; set; }

        /* EF Relations */
        public IEnumerable<Donation> Donations { get; set; }
        private readonly List<MemberGroup> _memberGroups = new List<MemberGroup>();
        private readonly List<MemberRole> _memberRoles = new List<MemberRole>();

        #region Groups

        public IEnumerable<MemberGroup> MemberGroups => _memberGroups;

        public void AddGroup(Group group) => _memberGroups.Add(new MemberGroup(group, this));

        public void UpdateGroup(IEnumerable<Group> groups)
        {
            foreach (Group item in groups)
            {
                if (!_memberGroups.Any(mg => mg.GroupId == item.Id))
                {
                    AddGroup(item);
                }
            }

            List<MemberGroup> groupsRemoved = new List<MemberGroup>();

            foreach (MemberGroup item in _memberGroups)
            {
                if (!groups.Any(g => g.Id == item.GroupId))
                {
                    groupsRemoved.Add(item);
                }
            }

            foreach (MemberGroup item in groupsRemoved)
            {
                _memberGroups.Remove(item);
            }
        }

        #endregion

        #region Roles

        public IEnumerable<MemberRole> MemberRoles => _memberRoles;

        public void AddRole(Role role) => _memberRoles.Add(new MemberRole(role, this));

        public void UpdateRole(IEnumerable<Role> roles)
        {
            foreach (Role item in roles)
            {
                if (!_memberRoles.Any(mr => mr.RoleId == item.Id))
                {
                    AddRole(item);
                }
            }

            List<MemberRole> rolesRemoved = new List<MemberRole>();

            foreach (MemberRole item in _memberRoles)
            {
                if (!roles.Any(g => g.Id == item.RoleId))
                {
                    rolesRemoved.Add(item);
                }
            }

            foreach (MemberRole item in rolesRemoved)
            {
                _memberRoles.Remove(item);
            }
        }

        #endregion
    }
}
