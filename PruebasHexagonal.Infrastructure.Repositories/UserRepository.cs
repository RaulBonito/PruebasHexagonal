using PruebasHexagonal.Domain.Abstractions.Repositories;
using PruebasHexagonal.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebasHexagonal.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public UserRepository() {

            _users.Add(new User { UserId = 1, Name = "Joaquín", LastName = "Pichardo", Email = "joaquin.pichardo@gmail.com", Password = "928374" });
            _users.Add(new User { UserId = 2, Name = "El", LastName = "Toque Toque", Email = "el.toquetoque@gmail.com", Password = "445512" });
            _users.Add(new User { UserId = 3, Name = "Dandy", LastName = "de Barcelona", Email = "dandy.bcn@gmail.com", Password = "882390" });
            _users.Add(new User { UserId = 4, Name = "La", LastName = "Falete", Email = "la.falete@gmail.com", Password = "110299" });
            _users.Add(new User { UserId = 5, Name = "David", LastName = "Evil", Email = "david.evil@gmail.com", Password = "773621" });


        }
        public Task<User> Add(User user)
        {
            _users.Add(user);
            return Task.FromResult(user);
        }

        public Task<bool> Delete(int userId)
        {
            var user = _users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
                return Task.FromResult(false);

            _users.Remove(user);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<User>> GetAll()
        {
            return Task.FromResult(_users.AsEnumerable());
        }

        public Task<User> GetById(int userId)
        {
            var user = _users.FirstOrDefault(u => u.UserId == userId);
            return Task.FromResult(user);
        }

        public Task<User> Update(User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.UserId == user.UserId);
            if (existingUser == null)
                return Task.FromResult<User>(null!);

            existingUser.Name = user.Name;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email; 


            return Task.FromResult(existingUser);
        }
    }
}
