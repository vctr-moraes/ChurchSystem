using System;

namespace ChurchSystem.Business.Models
{
    public class Schedule : Entity
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public Guid MemberId { get; set; }

        /* EF Relations */
        public Member Member { get; set; }
    }
}
