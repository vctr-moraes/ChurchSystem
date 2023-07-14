using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChurchSystem.Business.Models;

namespace ChurchSystem.Business.Interfaces
{
    public interface IDonationRepository : IRepository<Donation>
    {
        Task<Donation> GetDonation(Guid id);
        Task<Donation> GetDonationAsNoTracking(Guid id);
        List<Donation> GetDonations();
    }
}
