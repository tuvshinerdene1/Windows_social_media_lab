using SocialMedia.SocialMedia.Lib.Abstractions;
using SocialMedia.SocialMedia.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public void RegisterUser(string username, string password, byte age)
        {
            if (_userRepo.GetByUsername(username) != null)
            {
                Console.WriteLine("Error: Username already exists!");
                return;
            }

            var newUser = new User(username, password, age);
            _userRepo.add(newUser);
            Console.WriteLine($"User {username} registered successfully.");
        }
    }
}
