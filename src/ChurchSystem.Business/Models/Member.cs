﻿using System;
using System.Collections.Generic;

namespace ChurchSystem.Business.Models
{
    public class Member : Entity
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public DateTime DateBirth { get; set; }
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
        public List<MemberGroup> MemberGroups { get; set; } = new List<MemberGroup>();
        public List<MemberRole> MemberRoles { get; set; } = new List<MemberRole>();
    }
}
