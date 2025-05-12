using PruebasHexagonal.Application.Communication.V1.Responses;
using PruebasHexagonal.Domain.Abstractions.Presenters;
using PruebasHexagonal.Domain.Core.Responses;

namespace PruebasHexagonal.Infrastructure.Presenters.V1
{
    public class UserGetPresenter : IPresenter<UserGetResponse>
    {
        public async Task<AppResponse<UserGetResponse>> PresentAsync(UserGetResponse response)
        {
            return new AppResponse<UserGetResponse>
            {
                Success = true,
                Data = response,
                Message = "User retrieved successfully."
            };
        }
    }
}
