using SocialMedia.SocialMedia.Lib.Abstractions;
using SocialMedia.SocialMedia.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Repositories
{

    /// <summary>
    /// Найзын хүсэлтийг удирдах репозиторийн хэрэгжилт. Энэ класс нь найзын хүсэлтүүдийг хадгалах, авах, болон удирдах үүрэгтэй.
    /// </summary>
    public class FriendRequestRepository : IFriendRequestRepository
    {
        private readonly List<FriendRequest> _requests = new();

        public void add(FriendRequest entity) => _requests.Add(entity);
        public IEnumerable<FriendRequest> GetAll() => _requests;

        public FriendRequest GetById(Guid id)
        {
            return _requests.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<FriendRequest> GetIncomingRequests(string username)
            => _requests.Where(r => r.ReceiverUsername == username && r.Status == FriendRequestStatus.Pending);
    }
}
