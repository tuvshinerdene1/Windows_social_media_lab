using SocialMedia.SocialMedia.Lib.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Models
{
    public class User:BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }

        private readonly byte _age;
        public byte Age => _age;

        public User(string username,string password, byte age) {

            Username = username;
            Password = password;
            _age = age;
        }
        
    }
}
