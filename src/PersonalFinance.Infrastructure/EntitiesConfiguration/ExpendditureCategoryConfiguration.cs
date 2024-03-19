using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Infrastructure.EntitiesConfiguration;

public class ExpendditureCategoryConfiguration : IEntityTypeConfiguration<ExpenditureCategory>
{
    public void Configure(EntityTypeBuilder<ExpenditureCategory> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).UseIdentityColumn();

        builder.Property(e => e.Name).IsRequired().HasMaxLength(30);

        builder.Property(e => e.Description).IsRequired().HasMaxLength(100);

        builder.HasOne(e => e.User)
            .WithMany(u => u.ExpenditureCategories)
            .HasForeignKey(e => e.UserId);
        
        builder.Property(e => e.UserId).IsRequired();
    }
}