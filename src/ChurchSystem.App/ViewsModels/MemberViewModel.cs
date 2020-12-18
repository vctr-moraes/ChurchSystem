using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChurchSystem.App.ViewsModels
{
    public class MemberViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Name")]
        [Required(ErrorMessage ="The {0} field is required.")]
        [StringLength(200, ErrorMessage = "The {0} field must be between {2} and {1} characters.", MinimumLength = 2)]
        public string Name { get; set; }

        [DisplayName("Document")]
        [StringLength(100, ErrorMessage = "The {0} field must be between {2} and {1} characters.", MinimumLength = 2)]
        public string Document { get; set; }

        [DisplayName("DateBirth")]
        public DateTime DateBirth { get; set; }

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
        [StringLength(200, ErrorMessage = "The {0} field must be between {2} and {1} characters.", MinimumLength = 2)]
        public string Email { get; set; }

        [DisplayName("Phone number")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(11, ErrorMessage = "The {0} field must be between {2} and {1} characters.", MinimumLength = 10)]
        public string PhoneNumber { get; set; }

        [DisplayName("Baptized")]
        public bool Baptized { get; set; }

        [DisplayName("Status")]
        public bool Status { get; set; }

        [ScaffoldColumn(false)]
        public DateTime RegistrationDate { get; set; }

        [Display(Name = "Groups")]
        [Required(ErrorMessage = "The {0} field is required.")]
        public Guid GroupId { get; set; }

        public GroupViewModel Group { get; set; }

        public IEnumerable<GroupViewModel> Groups { get; set; }

        [Display(Name = "Roles")]
        [Required(ErrorMessage = "The {0} field is required.")]
        public Guid RoleId { get; set; }

        public RoleViewModel Role { get; set; }

        public IEnumerable<RoleViewModel> Roles { get; set; }
    }
}
