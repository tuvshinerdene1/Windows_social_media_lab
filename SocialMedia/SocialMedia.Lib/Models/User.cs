using SocialMedia.SocialMedia.Lib.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Models
{

    public enum UserRole { Member, Admin}
    /// <summary>
    /// Хэрэглэгчийг төлөөлөх класс. Хэрэглэгчийн нэр, нууц үг, нас болон үүрэг зэрэг мэдээллийг агуулдаг.
    /// </summary>
    public class User:BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserRole Role { get; set; }
        private readonly byte _age;
        public byte Age => _age;

        public User(string username,string password, byte age, UserRole role = UserRole.Member) {

            Username = username;
            Password = password;
            _age = age;
            Role = role;
        }
        
    }
}
