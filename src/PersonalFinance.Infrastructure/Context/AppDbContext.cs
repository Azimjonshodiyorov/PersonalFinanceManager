using Microsoft.EntityFrameworkCore;
using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Infrastructure.Context;

public class AppDbContext  : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> contextOptions) : base(contextOptions)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Revenue> Revenues { get; set; }
    public DbSet<RevenueCategory> RevenueCategories { get; set; }
    public DbSet<Expenditure> Expenditures { get; set; }
    public DbSet<ExpenditureCategory> ExpenditureCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}