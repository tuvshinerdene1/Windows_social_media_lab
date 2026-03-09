using SocialMedia.SocialMedia.Lib.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Models
{
    public enum FriendRequestStatus { Pending, Accepted, Declined }

    /// <summary>
    /// Найзын хүсэлтийг төлөөлөх класс. Найзын хүсэлт нь илгээгч болон хүлээн авагчийн нэр, мөн хүсэлтийн статусыг агуулдаг.
    /// </summary>
    public class FriendRequest : BaseEntity
    {
        public string SenderUsername { get; set; }
        public string ReceiverUsername { get; set; }
        public FriendRequestStatus Status { get; set; } = FriendRequestStatus.Pending;

        public FriendRequest(string sender, string receiver)
        {
            SenderUsername = sender;
            ReceiverUsername = receiver;
        }
    }
}
