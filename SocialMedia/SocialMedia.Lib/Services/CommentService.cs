using SocialMedia.SocialMedia.Lib.Abstractions;
using SocialMedia.SocialMedia.Lib.Models;
using SocialMedia.SocialMedia.Lib.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Services
{
    /// <summary>
    /// Коммент бичих үйлдлийг удирдах класс.
    /// </summary>
    public class CommentService
    {
        public void AddComment(ICommentable target, User author, string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return;

            var newComment = new Comment(author.Username, text, ((BaseEntity)target).Id
                );
            target.Comments.Add(newComment);

            Console.WriteLine("Comment added successfully");

        }
    }
}
