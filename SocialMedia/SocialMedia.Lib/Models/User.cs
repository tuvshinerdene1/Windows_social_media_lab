using SocialMedia.SocialMedia.Lib.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Models
{
    public class User:BaseEntity
    {
        public string Username { get; set; }
        private readonly byte _age;
        public byte Age => _age;

        public User(string username, byte age) {

            Username = username;
            _age = age;
        }
        
    }
}
