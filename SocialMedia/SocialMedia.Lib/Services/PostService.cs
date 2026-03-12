using SocialMedia.SocialMedia.Lib.Abstractions;
using SocialMedia.SocialMedia.Lib.Models;
using SocialMedia.SocialMedia.Lib.Repositories;

namespace SocialMedia.SocialMedia.Lib.Services
{
    /// <summary>
    /// Пост үүсгэх болон лайк хийх үйлдлийг удирдах үйлчилгээний класс.
    /// </summary>
    public class PostService
    {
        private readonly PostRepository _repo;

        public PostService(PostRepository repo)
        {
            _repo = repo;
        }

        public void CreatePost(User user, string content)
        {
            var post = new Post { authorId = user.Username, Content = content };
            _repo.add(post);
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _repo.GetAll();
        }
        public Post GetPost(Guid id)
        {
            return _repo.GetById(id);
        }


        public void LikePost(Ilikeable target, string username)
        {
            if (target.LikedByUsers.Contains(username))
            {
                target.LikedByUsers.Remove(username);
                Console.WriteLine("Post unliked");
            }
            else
            {
                target.LikedByUsers.Add(username);
                Console.WriteLine("Post liked");
            }
        }
        public List<Post> GetFeed()
        {
            return _repo.GetAll().OrderByDescending(p => p.CreatedAt).ToList();
        }
    }
}
