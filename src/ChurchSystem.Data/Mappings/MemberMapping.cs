using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChurchSystem.Business.Models;

namespace ChurchSystem.Data.Mappings
{
    public class MemberMapping : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder
                .Property(m => m.Document)
                .HasColumnType("varchar(50)");

            builder
                .Property(m => m.Address)
                .HasColumnType("varchar(100)");

            builder
                .Property(m => m.Neighborhood)
                .HasColumnType("varchar(100)");

            builder
                .Property(m => m.City)
                .HasColumnType("varchar(100)");

            builder
                .Property(m => m.State)
                .HasColumnType("varchar(50)");

            builder
                .Property(m => m.Mailbox)
                .HasColumnType("varchar(50)");

            builder
                .Property(m => m.Email)
                .HasColumnType("varchar(150)");

            builder
                .Property(m => m.PhoneNumber)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder
                .Property(m => m.RegistrationDate)
                .HasColumnType("date");

            // 1 : N => Member : Donations
            builder
                .HasMany(m => m.Donations)
                .WithOne(d => d.Member)
                .HasForeignKey(d => d.MemberId);

            builder
                .ToTable("Members");
        }
    }
}
