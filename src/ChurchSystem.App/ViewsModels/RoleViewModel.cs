using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ChurchSystem.Business.Models;

namespace ChurchSystem.App.ViewsModels
{
    public class RoleViewModel
    {
        public RoleViewModel() { }

        public RoleViewModel(Role role)
        {
            Id = role.Id;
            Description = role.Description;
        }

        [Key]
        public Guid Id { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(200, ErrorMessage = "The {0} field must be between {2} and {1} characters.", MinimumLength = 2)]
        public string Description { get; set; }
    }
}
