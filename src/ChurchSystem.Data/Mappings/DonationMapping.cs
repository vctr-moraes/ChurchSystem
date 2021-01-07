using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChurchSystem.Business.Models;

namespace ChurchSystem.Data.Mappings
{
    public class DonationMapping : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Date)
                .IsRequired()
                .HasColumnType("date");

            builder
                .Property(d => d.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder
                .Property(d => d.Type)
                .IsRequired();

            builder
                .ToTable("Donations");
        }
    }
}
