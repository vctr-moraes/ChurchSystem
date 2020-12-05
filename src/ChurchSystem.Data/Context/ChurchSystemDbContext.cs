using ChurchSystem.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace ChurchSystem.Data.Context
{
    public class ChurchSystemDbContext : DbContext
    {
        public ChurchSystemDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Donation> Donations { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
    }
}
