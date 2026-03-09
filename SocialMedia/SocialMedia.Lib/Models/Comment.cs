using SocialMedia.SocialMedia.Lib.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Models
{
    /// <summary>
    /// Хэрэглэгчийн бичсэн сэтгэгдлийг төлөөлөх класс.
    /// </summary>
    public class Comment : ContentBase
    {
        public Guid TargetId { get; set; }

        public Comment(string authorId, string content, Guid targetId)
        {
            this.authorId = authorId;
            this.Content = content;
            this.TargetId = targetId;
        }
       
    }
}
