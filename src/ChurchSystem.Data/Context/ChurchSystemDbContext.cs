using ChurchSystem.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace ChurchSystem.Data.Context
{
    public class ChurchSystemDbContext : DbContext
    {
        public ChurchSystemDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Donation> Donations { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Role> ListRoles { get; set; }
        public DbSet<MemberGroup> MemberGroups { get; set; }
        public DbSet<MemberRole> MemberRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ChurchSystemDbContext).Assembly);

            base.OnModelCreating(builder);
        }
    }
}
