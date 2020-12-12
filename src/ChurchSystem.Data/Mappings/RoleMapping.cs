using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChurchSystem.Business.Models;

namespace ChurchSystem.Data.Mappings
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
                .HasKey(r => r.Id);

            builder
                .Property(r => r.Description)
                .IsRequired()
                .HasColumnType("varchar(200)");

            // 1 : N => Role : Members
            builder
                .HasMany(r => r.Members)
                .WithOne(m => m.Role)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .ToTable("ListRoles");
        }
    }
}
