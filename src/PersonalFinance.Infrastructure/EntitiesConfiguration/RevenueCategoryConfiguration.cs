using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Infrastructure.EntitiesConfiguration;

public class RevenueCategoryConfiguration : IEntityTypeConfiguration<RevenueCategory>
{
    public void Configure(EntityTypeBuilder<RevenueCategory> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).UseIdentityColumn();

        builder.Property(r => r.Name).IsRequired().HasMaxLength(30);

        builder.Property(r => r.Description).IsRequired().HasMaxLength(100);

        builder.HasOne(r => r.User)
            .WithMany(u => u.RevenueCategories).
            HasForeignKey(r => r.UserId);
        
        builder.Property(r => r.UserId).IsRequired();

    }
}