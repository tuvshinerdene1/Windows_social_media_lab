using SocialMedia.SocialMedia.Lib.Abstractions;
using SocialMedia.SocialMedia.Lib.Models;

namespace SocialMedia.SocialMedia.Lib.Services
{
    /// <summary>
    /// найзын хүсэлт илгээх болон хүлээн авах үйлдлийг удирдах үйлчилгээний класс.
    /// </summary>
    public class FriendService
    {
        private readonly IFriendRequestRepository _repo;

        public FriendService(IFriendRequestRepository repo)
        {
            _repo = repo;
        }

        public void SendRequest(string sender, string receiver)
        {
            if (sender == receiver)
            {
                Console.WriteLine("Error: You cannot send a friend request to yourself.");
                return;
            }

            var exists = _repo.GetAll().Any(r => r.SenderUsername == sender && r.ReceiverUsername == receiver);
            if (exists)
            {
                Console.WriteLine("Error: Request already sent.");
                return;
            }

            _repo.add(new FriendRequest(sender, receiver));
            Console.WriteLine($"Friend request sent to {receiver}!");
        }

        public void RespondToRequest(Guid requestId, bool accept)
        {
            var request = _repo.GetAll().FirstOrDefault(r => r.Id == requestId);
            if (request != null)
            {
                request.Status = accept ? FriendRequestStatus.Accepted : FriendRequestStatus.Declined;
                Console.WriteLine(accept ? "Request Accepted!" : "Request Declined.");
            }
        }
        public List<string> GetFriendsList(string username)
        {
            var acceptedRequests = _repo.GetAcceptedRequests(username);

            return acceptedRequests.Select(r =>
                r.SenderUsername == username ? r.ReceiverUsername : r.SenderUsername
            ).ToList();
        }
        public List<FriendRequest> GetPendingRequests(string username)
        {
            return _repo.GetIncomingRequests(username).ToList();
        }
    }
}
