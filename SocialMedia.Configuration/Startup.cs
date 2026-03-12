
using SocialMedia.SocialMedia.Lib.Repositories;
using SocialMedia.SocialMedia.Lib.Services;

namespace SocialMedia.Configuration
{
    public class Startup
    {
        public static ServiceManager ConfigureServices()
        {
            var userRepo = new UserRepository();
            var postRepo = new PostRepository();
            var friendRepo = new FriendRequestRepository();

            var userService = new UserService(userRepo);
            var authService = new AuthService(userRepo);
            var postService = new PostService(postRepo);
            var friendService = new FriendService(friendRepo);
            var commentService = new CommentService();

            return new ServiceManager(
            userService,
            authService,
            postService,
            friendService,
            commentService
        );
        }
    }
}
