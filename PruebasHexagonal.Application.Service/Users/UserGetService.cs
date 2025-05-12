using PruebasHexagonal.Domain.Abstractions.Repositories;
using PruebasHexagonal.Domain.Abstractions.Services.Users;
using PruebasHexagonal.Domain.Core.Entities;

namespace PruebasHexagonal.Application.Services.Users
{
    public class UserGetService : IUserGetService
    {
        private readonly IUserRepository _repository;
        public UserGetService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<User> GetUserAsync(int UserId)
        {
            return await _repository.GetById(UserId);
        }
    }
}
