using SocialMedia.SocialMedia.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Abstractions
{
    /// <summary>
    /// Найзын хүсэлтийг удирдах репозиторийн интерфейс.
    /// </summary>
    public interface IFriendRequestRepository : IRepository<FriendRequest>
    {
      
        IEnumerable<FriendRequest> GetIncomingRequests(string username);
        IEnumerable<FriendRequest> GetAcceptedRequests(string username);
    }
}
