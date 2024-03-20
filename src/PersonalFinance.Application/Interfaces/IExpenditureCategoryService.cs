using PersonalFinance.Application.ViewModel.Request.ExpenditureCategory;
using PersonalFinance.Application.ViewModel.Response;

namespace PersonalFinance.Application.Interfaces;

public interface IExpenditureCategoryService
{
    ValueTask<ExpenditureCategoryResponse> GetByIdAndUserId(long id, long userId);
    ValueTask<List<ExpenditureCategoryResponse>> GetByUserId(long userId);

    ValueTask<ExpenditureCategoryResponse> Create(CreateExpendditureCategoryRequest expendditureCategoryRequest,
        long id, long userId);

    ValueTask<ExpenditureCategoryResponse> Update(UpdateExpenditureCategoryRequest expenditureCategoryRequest, long id,
        long userId);

    ValueTask<ExpenditureCategoryResponse> Delete(long id, long userId);

}