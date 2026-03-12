namespace SocialMedia.SocialMedia.Lib.Services
{
    public class ServiceManager
    {
        public UserService User { get; }
        public AuthService Auth { get; }
        public PostService Post { get; }
        public FriendService Friend { get; }
        public CommentService Comment { get; }

        public ServiceManager(
            UserService user,
            AuthService auth,
            PostService post,
            FriendService friend,
            CommentService comment)
        {
            User = user;
            Auth = auth;
            Post = post;
            Friend = friend;
            Comment = comment;
        }
    }
}
