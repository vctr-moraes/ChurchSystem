using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChurchSystem.Business.Models;

namespace ChurchSystem.Data.Mappings
{
    public class GroupMapping : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder
                .HasKey(g => g.Id);

            builder
                .Property(g => g.Description)
                .IsRequired()
                .HasColumnType("varchar(200)");

            // 1 : N => Group : Members
            builder
                .HasMany(g => g.Members)
                .WithOne(m => m.Group)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .ToTable("Groups");
        }
    }
}
