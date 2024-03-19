using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Application.ViewModel.Response;

public class ExpenditureResponse
{
    public long Id { get; set; }

    public string Name { get; set; }
        
    public DateTime Date { get; set; }

    public decimal Value { get; set; }

    public string Description { get; set; }

    public long UserId { get; set; }

    public long ExpenditureCategoryId { get; set; }

    public ExpenditureCategory ExpenditureCategory { get; set; }
}