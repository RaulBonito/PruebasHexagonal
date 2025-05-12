using AutoMapper;
using PruebasHexagonal.Application.Communication.V1.Requests;
using PruebasHexagonal.Application.Communication.V1.Responses;
using PruebasHexagonal.Application.Communication.V1.ViewModels;
using PruebasHexagonal.Domain.Abstractions.Handlers;
using PruebasHexagonal.Domain.Abstractions.Services.Users;
using PruebasHexagonal.Domain.Core.Entities;

namespace PruebasHexagonal.Application.Handlers
{
    public class UserGetHandler (IUserGetService userGetService, IMapper mapper): IHandler<UserGetRequest, UserGetResponse>
    {
        private readonly IUserGetService _userGetService = userGetService ?? throw new ArgumentNullException(nameof(userGetService));
        private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        public async Task<UserGetResponse> HandleAsync(UserGetRequest request)
        {
            var user = await _userGetService.GetUserAsync(request.UserId);

            var mappedUser = _mapper.Map<UserViewModel>(user);

            return new UserGetResponse
            {
                User = mappedUser
            };

        }
    }
}
