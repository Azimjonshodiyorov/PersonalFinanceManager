using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Infrastructure.EntitiesConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();
        builder.Property(x => x.Username).IsRequired().HasMaxLength(20);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Password).IsRequired().HasMaxLength(100);
        builder.Property(x => x.CreateAt).IsRequired();

        builder.HasOne(x => x.UserRole)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.UserRoleId);
        builder.Property(x => x.UserRoleId).IsRequired();
        builder.Property(x => x.IsEmailValid).IsRequired();
    }
}