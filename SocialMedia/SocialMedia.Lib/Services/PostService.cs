using SocialMedia.SocialMedia.Lib.Models;
using SocialMedia.SocialMedia.Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Services { 
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
}
}
