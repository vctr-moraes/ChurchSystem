using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChurchSystem.App.ViewsModels
{
    public class DonationViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        
        [Display(Name = "Amount")]
        [Required(ErrorMessage = "The {0} field is required.")]
        public decimal Amount { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "The {0} field is required.")]
        public int Type { get; set; }

        [Display(Name = "Member")]
        [Required(ErrorMessage = "The {0} field is required.")]
        public Guid MemberId { get; set; }

        public MemberViewModel Member { get; set; }
        
        public IEnumerable<MemberViewModel> Members { get; set; }
    }
}
