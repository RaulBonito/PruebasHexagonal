using PruebasHexagonal.Domain.Core.Entities;

namespace PruebasHexagonal.Domain.Abstractions.Services.Users
{
    public interface IUserGetService
    {
        Task<User> GetUserAsync(int UserId);
    }
}
