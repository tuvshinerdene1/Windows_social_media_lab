using SocialMedia.SocialMedia.Lib.Abstractions;
using SocialMedia.SocialMedia.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        // From IRepository<User>
        public void add(User entity) => _users.Add(entity);

        public IEnumerable<User> GetAll() => _users;

        public User GetById(Guid id) => _users.FirstOrDefault(u => u.Id == id);

        // From IUserRepository (Specific)
        public User GetByUsername(string username)
            => _users.FirstOrDefault(u => u.Username == username);

    }
}
