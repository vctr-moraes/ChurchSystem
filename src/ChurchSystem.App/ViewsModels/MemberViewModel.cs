using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ChurchSystem.Business.Models;
using System.Linq;

namespace ChurchSystem.App.ViewsModels
{
    public class MemberViewModel
    {
        public MemberViewModel() { }

        public MemberViewModel(Member member)
        {
            Id = member.Id;
            Name = member.Name;
            Document = member.Document;
            DateBirth = member.DateBirth;
            Address = member.Address;
            Neighborhood = member.Neighborhood;
            City = member.City;
            State = member.State;
            Mailbox = member.Mailbox;
            Email = member.Email;
            PhoneNumber = member.PhoneNumber;
            Baptized = member.Baptized;
            Status = member.Status;
            RegistrationDate = member.RegistrationDate;
            GroupsIds = member.MemberGroups.Select(g => g.Group.Id).ToArray();
            RolesIds = member.MemberRoles.Select(r => r.Role.Id).ToArray();
            MemberGroups = new List<MemberGroupViewModel>();
            MemberRoles = new List<MemberRoleViewModel>();

            foreach (var item in member.MemberGroups)
            {
                MemberGroups.Add(new MemberGroupViewModel(item));
            }

            foreach (var item in member.MemberRoles)
            {
                MemberRoles.Add(new MemberRoleViewModel(item));
            }
        }

        [Key]
        public Guid Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage ="The {0} field is required.")]
        [StringLength(200, ErrorMessage = "The {0} field must be between {2} and {1} characters.", MinimumLength = 2)]
        public string Name { get; set; }

        [DisplayName("Document")]
        [StringLength(100, ErrorMessage = "The {0} field must be between {2} and {1} characters.", MinimumLength = 2)]
        public string Document { get; set; }

        [DisplayName("Date of birth")]
        [DataType(DataType.Date)]
        public DateTime? DateBirth { get; set; }

        [DisplayName("Address")]
        [StringLength(200, ErrorMessage = "The {0} field must be between {2} and {1} characters.", MinimumLength = 2)]
        public string Address { get; set; }

        [DisplayName("Neighborhood")]
        [StringLength(100, ErrorMessage = "The {0} field must be between {2} and {1} characters.", MinimumLength = 2)]
        public string Neighborhood { get; set; }

        [DisplayName("City")]
        [StringLength(100, ErrorMessage = "The {0} field must be between {2} and {1} characters.", MinimumLength = 2)]
        public string City { get; set; }

        [DisplayName("State")]
        [StringLength(50, ErrorMessage = "The {0} field must be between {2} and {1} characters.", MinimumLength = 2)]
        public string State { get; set; }

        [DisplayName("Mailbox")]
        [StringLength(15, ErrorMessage = "The {0} field must be between {2} and {1} characters.", MinimumLength = 8)]
        public string Mailbox { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(200, ErrorMessage = "The {0} field must be between {2} and {1} characters.", MinimumLength = 2)]
        public string Email { get; set; }

        [DisplayName("Phone number")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(11, ErrorMessage = "The {0} field must be between {2} and {1} characters.", MinimumLength = 10)]
        public string PhoneNumber { get; set; }

        [DisplayName("Member baptized?")]
        public bool Baptized { get; set; }

        [DisplayName("Member active?")]
        public bool Status { get; set; } = true;

        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        #region Groups

        [Display(Name = "Groups")]
        public Guid GroupId { get; set; }

        [Display(Name = "Groups")]
        public Guid[] GroupsIds { get; set; }

        public GroupViewModel Group { get; set; }

        public IEnumerable<SelectListItem> Groups { get; set; }

        public List<MemberGroupViewModel> MemberGroups { get; set; }

        #endregion

        #region Roles

        [Display(Name = "Roles")]
        public Guid RoleId { get; set; }

        [Display(Name = "Roles")]
        public Guid[] RolesIds { get; set; }

        public RoleViewModel Role { get; set; }

        public List<MemberRoleViewModel> MemberRoles { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }

        #endregion
    }
}
