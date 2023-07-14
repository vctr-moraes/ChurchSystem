using ChurchSystem.Business.Models;
using ChurchSystem.Business.Interfaces;
using ChurchSystem.Data.Context;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ChurchSystem.Data.Repository
{
    public class DonationRepository : Repository<Donation>, IDonationRepository
    {
        public DonationRepository(ChurchSystemDbContext context) : base(context) { }

        public async Task<Donation> GetDonation(Guid id)
        {
            return await Db.Donations
                .Include(d => d.Member)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Donation> GetDonationAsNoTracking(Guid id)
        {
            return await Db.Donations.AsNoTracking()
                .Include(d => d.Member)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public List<Donation> GetDonations()
        {
            return Db.Donations.Include(d => d.Member).ToList();
        }
    }
}
