using SocialMedia.SocialMedia.Lib.Abstractions;
using SocialMedia.SocialMedia.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Repositories
{
    public class PostRepository : IRepository<Post>
    {
        private List<Post> _posts = new();
        public void add(Post entity) => _posts.Add(entity);

        public IEnumerable<Post> GetAll() => _posts;
        public Post GetById(Guid id)
        {
            return _posts.Find(p => p.Id == id);
        }
    }
}
