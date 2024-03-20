using PersonalFinance.Application.ViewModel.Request.Expenditure;
using PersonalFinance.Application.ViewModel.Response;

namespace PersonalFinance.Application.Interfaces;

public interface IExpenditureService
{
    ValueTask<ExpenditureResponse> GetByIdAndUserId(long id, long userId);
    ValueTask<List<ExpenditureResponse>> GetByUserId(long userId);
    ValueTask<ExpenditureResponse> Create(CreateExpenditureRequest expenditureRequest, long userId);
    ValueTask<ExpenditureResponse> Update(UpdateExpendidureRequest expendidureRequest, long id, long userId);
    ValueTask<ExpenditureResponse> Delete(long id, long userId);
}