
using SocialMedia.SocialMedia.Lib.Models;
using SocialMedia.SocialMedia.Lib.Services;
using SocialMedia.SocialMedia.Lib.Repositories;


class Program
{
    static void Main(string[] args)
    {
        // 1. Initialize logic
        var postRepo = new PostRepository();
        var postService = new PostService(postRepo);

        // 2. Create User (Byte age check)
        User myUser = new User("John_Doe", 25);
        Console.WriteLine($"User: {myUser.Username}, Age: {myUser.Age}");

        // 3. Perform Actions
        postService.CreatePost(myUser, "Hello world, this is my first clone post!");

        var post = postRepo.GetAll().First();
        post.Like();
        post.Share("X (Twitter)");

        Console.WriteLine($"Post Likes: {post.LikeCount}");
    }
}