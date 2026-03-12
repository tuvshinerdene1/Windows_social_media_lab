using SocialMedia.SocialMedia.Lib.Abstractions;
using SocialMedia.SocialMedia.Lib.Models;

namespace SocialMedia.SocialMedia.Lib.Services
{
    /// <summary>
    /// Хэрэглэгчийн бүртгэл үүсгэх үйлдлийг удирдах үйлчилгээний класс.
    /// </summary>
    public class UserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public User GetUser(string username)
        {
            var user = _userRepo.GetByUsername(username);
            if (user == null)
            {
                Console.WriteLine($"Warning: User {username} not found");
            }
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepo.GetAll();
        }


        public void RegisterUser(string username, string password, byte age, UserRole role)
        {
            if (_userRepo.GetByUsername(username) != null)
            {
                Console.WriteLine("Error: Username already exists!");
                return;
            }

            var newUser = new User(username, password, age, role);
            _userRepo.add(newUser);
            Console.WriteLine($"User {username} registered successfully.");
        }
    }
}
