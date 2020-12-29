using System.ComponentModel.DataAnnotations;

namespace ChurchSystem.App.ViewsModels
{
    public enum DonationTypeViewModel
    {
        [Display(Name = "Donation")]
        Donation = 1,

        [Display(Name = "Tithing")]
        Tithing = 2
    }
}
