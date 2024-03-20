using PersonalFinance.Application.ViewModel.Request.RevenueCategory;
using PersonalFinance.Application.ViewModel.Response;

namespace PersonalFinance.Application.Interfaces;

public interface IRevenueCategoryService
{
    ValueTask<RevenueCategoryResponse> GetByIdAndUserId(long id, long userId);
    ValueTask<List<RevenueCategoryResponse>> GetByUserId(long userId);
    ValueTask<RevenueCategoryResponse> Create(CreateRevenueCategoryRequest revenueCategoryRequest, long userId);

    ValueTask<RevenueCategoryResponse> Update(UpdateRevenueCategoryRequest revenueCategoryRequest, long id,
        long userId);

    ValueTask<RevenueCategoryResponse> Delete(long id, long userId);
}