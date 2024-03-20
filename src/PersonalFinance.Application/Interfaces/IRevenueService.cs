using PersonalFinance.Application.ViewModel.Request.Revenue;
using PersonalFinance.Application.ViewModel.Response;

namespace PersonalFinance.Application.Interfaces;

public interface IRevenueService
{
    ValueTask<RevenueResponse> GetByIdAndUserId(long id, long userId);
    ValueTask<List<RevenueResponse>> GetByUserId(long userId);
    ValueTask<RevenueResponse> Create(CreateRevenueRequest revenueRequest , long userId);
    ValueTask<RevenueResponse> Update(UpdateRevenueRequest revenueRequest, long id ,long userId);
    ValueTask<RevenueResponse> Delete(long id, long userId);
}