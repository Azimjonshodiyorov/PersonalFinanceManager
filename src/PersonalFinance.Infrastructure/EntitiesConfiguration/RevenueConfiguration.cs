using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Infrastructure.EntitiesConfiguration;

public class RevenueConfiguration : IEntityTypeConfiguration<Revenue>
{
    public void Configure(EntityTypeBuilder<Revenue> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn();

        builder.Property(x => x.Name).IsRequired().HasMaxLength(30);

        builder.Property(x => x.Date).IsRequired();
        builder.Property(x => x.Value).IsRequired().HasPrecision(18, 2);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(100);

        builder.HasOne(x => x.RevenueCategory)
            .WithMany(x => x.Revenues)
            .HasForeignKey(x => x.UserId);
        builder.Property(x => x.UserId).IsRequired();

        builder.HasOne(x => x.RevenueCategory)
            .WithMany(x => x.Revenues)
            .HasForeignKey(x => x.RevenueCategoryId);
        builder.Property(x => x.RevenueCategoryId).IsRequired();

    }
}