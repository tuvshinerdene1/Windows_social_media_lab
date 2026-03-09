using SocialMedia.SocialMedia.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Abstractions
{
    /// <summary>
    /// Хэрэглэгчийн мэдээллийг удирдах репозиторийн интерфейс.
    /// </summary>
    public interface IUserRepository : IRepository<Models.User>
    {
        User GetByUsername(string username);
    }
}
