using SocialMedia.SocialMedia.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Abstractions
{
    public interface IUserRepository : IRepository<Models.User>
    {
        User GetByUsername(string username);
    }
}
