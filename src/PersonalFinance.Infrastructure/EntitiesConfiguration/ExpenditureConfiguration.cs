using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Infrastructure.EntitiesConfiguration;

public class ExpenditureConfiguration : IEntityTypeConfiguration<Expenditure>
{
    public void Configure(EntityTypeBuilder<Expenditure> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).UseIdentityColumn();

        builder.Property(e => e.Name).IsRequired().HasMaxLength(30);

        builder.Property(e => e.CreateAt).IsRequired();

        builder.Property(e => e.Value).IsRequired().HasPrecision(18,2);

        builder.Property(e => e.Description).IsRequired().HasMaxLength(100);

        builder.HasOne(e => e.User)
            .WithMany(u => u.Expenditures)
            .HasForeignKey(e => e.UserId);
        builder.Property(e => e.UserId).IsRequired();

        builder.HasOne(e => e.ExpenditureCategory)
            .WithMany(e => e.Expenditures)
            .HasForeignKey(e => e.ExpenditureCategoryId);
        builder.Property(e => e.ExpenditureCategoryId).IsRequired();


    }
}