using ChurchSystem.Business.Models;
using ChurchSystem.Business.Interfaces;
using ChurchSystem.Data.Context;

namespace ChurchSystem.Data.Repository
{
    public class DonationRepository : Repository<Donation>, IDonationRepository
    {
        public DonationRepository(ChurchSystemDbContext context) : base(context) { }
    }
}
