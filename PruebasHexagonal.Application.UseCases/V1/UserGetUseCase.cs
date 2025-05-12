using FluentValidation;
using PruebasHexagonal.Application.Communication.V1.Requests;
using PruebasHexagonal.Application.Communication.V1.Responses;
using PruebasHexagonal.Domain.Abstractions.Handlers;
using PruebasHexagonal.Domain.Abstractions.Presenters;
using PruebasHexagonal.Domain.Abstractions.UseCases;
using PruebasHexagonal.Domain.Core.Responses;

namespace PruebasHexagonal.Application.UseCases.V1;

public class UserGetUseCase(
    IHandler<UserGetRequest, UserGetResponse> handler,
    IValidator<UserGetRequest> validator,
    IPresenter<UserGetResponse> presenter)
    : IUseCase<UserGetRequest, AppResponse<UserGetResponse>>
{
    private readonly IHandler<UserGetRequest, UserGetResponse> _handler = handler;
    private readonly IValidator<UserGetRequest> _validator = validator;
    private readonly IPresenter<UserGetResponse> _presenter = presenter;

    public async Task<AppResponse<UserGetResponse>> ExecuteAsync(UserGetRequest request)
    {
        try
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid) throw new Exception(validationResult.ToString());

            var result = await _handler.HandleAsync(request);
            return await _presenter.PresentAsync(result);

        }
        catch (Exception ex)
        {
            return new AppResponse<UserGetResponse>
            {
                Success = false,
                Message = ex.Message,
                Data = null
            };
        }
    }
}
