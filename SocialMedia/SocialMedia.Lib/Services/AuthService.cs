using SocialMedia.SocialMedia.Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Services
{
    /// <summary>
    /// Хэрэглэгчийн нэвтрэлт болон гарах үйлдлийг удирдах үйлчилгээний класс.
    /// </summary>
    public class AuthService
    {
        private readonly UserRepository _userRepo;
        public Models.User? CurrentUser { get; private set; }

        public AuthService(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public bool Login(string username, string password)
        {
            var user = _userRepo.GetByUsername(username);
            if (user != null && user.Password == password)
            {
                CurrentUser = user;
                Console.WriteLine($"Login successful! Welcome {username}");
                return true;
            }
            Console.WriteLine("Invalid credentials.");
            return false;

        }

        public void Logout()
        {
            CurrentUser = null;
            Console.WriteLine("Logged out. Have a nice day :) ");
        }

    }
}
