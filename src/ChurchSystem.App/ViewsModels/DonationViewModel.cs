using ChurchSystem.Business.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChurchSystem.App.ViewsModels
{
    public class DonationViewModel
    {
        public DonationViewModel() { }

        public DonationViewModel(Donation donation)
        {
            Id = donation.Id;
            Date = donation.Date;
            Amount = donation.Amount;
            Type = (DonationTypeViewModel)donation.Type;
            MemberId = donation.MemberId;
            Member = new MemberViewModel(donation.Member);
            MemberName = donation.Member.Name;
        }

        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "The {0} field is required.")]
        public DateTime Date { get; set; }
        
        [Display(Name = "Amount")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "The {0} field is required.")]
        public decimal Amount { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "The {0} field is required.")]
        public DonationTypeViewModel Type { get; set; }

        [Display(Name = "Member")]
        [Required(ErrorMessage = "The {0} field is required.")]
        public Guid MemberId { get; set; }

        public MemberViewModel Member { get; set; }

        [Display(Name = "Member name")]
        public string MemberName { get; set; }

        public IEnumerable<SelectListItem> Members { get; set; }
    }
}
