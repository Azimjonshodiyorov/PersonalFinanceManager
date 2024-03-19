using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Application.ViewModel.Response;

public class RevenueResponse
{
    public long Id { get; set; }

    public string Name { get; set; }
        
    public DateTime Date { get; set; }

    public decimal Value { get; set; }

    public string Description { get; set; }

    public long RevenueCategoryId { get; set; }

    public RevenueCategory RevenueCategory { get; set; }
}