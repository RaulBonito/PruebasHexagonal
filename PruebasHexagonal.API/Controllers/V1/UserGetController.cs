using Microsoft.AspNetCore.Mvc;
using PruebasHexagonal.Application.Communication.V1.Requests;
using PruebasHexagonal.Application.Communication.V1.Responses;
using PruebasHexagonal.Application.UseCases.V1;
using PruebasHexagonal.Domain.Abstractions.UseCases;
using PruebasHexagonal.Domain.Core.Responses;

namespace PruebasHexagonal.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/users")]
    public class UserGetController : ControllerBase
    {
        private readonly IUseCase<UserGetRequest, AppResponse<UserGetResponse>> _userGetUseCase;

        public UserGetController(IUseCase<UserGetRequest, AppResponse<UserGetResponse>> userGetUseCase)
        {
            _userGetUseCase = userGetUseCase ?? throw new ArgumentNullException(nameof(userGetUseCase));
        }

        [HttpPost("get")]
        public async Task<IActionResult> GetUser([FromBody] UserGetRequest request)
        {
            var response = await _userGetUseCase.ExecuteAsync(request);

            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Data);
        }
    }
}
