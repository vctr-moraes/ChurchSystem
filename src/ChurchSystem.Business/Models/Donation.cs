using System;

namespace ChurchSystem.Business.Models
{
    public class Donation : Entity
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public DonationType Type { get; set; }
        public Guid MemberId { get; set; }

        /* EF Relations */
        public Member Member { get; set; }
    }
}
