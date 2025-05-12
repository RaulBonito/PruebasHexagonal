using PruebasHexagonal.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebasHexagonal.Domain.Abstractions.Services.Users
{
    public interface IUserListService
    {
        Task<IEnumerable<User>> ListAsync();
    }
}
