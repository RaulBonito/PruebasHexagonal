using PruebasHexagonal.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasHexagonal.Domain.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(int UserId);
        Task<IEnumerable<User>> GetAll();
        Task<User> Add(User user);
        Task<User> Update(User user);

        Task<bool> Delete(int UserId);
    }
}
