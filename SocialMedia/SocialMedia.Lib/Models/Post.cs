using SocialMedia.SocialMedia.Lib.Abstractions;
using SocialMedia.SocialMedia.Lib.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Models
{
    /// <summary>
    /// Постыг төлөөлөх класс. Хэрэглэгчийн бичсэн постыг илэрхийлэх бөгөөд лайк, сэтгэгдэл бичих боломжтой.
    /// </summary>
    public class Post : ContentBase, Ilikeable, ISharable, ICommentable
    {
        public List<string> LikedByUsers { get; set; } = new List<string>();
        public List<Comment> Comments { get; set; } = new List<Comment>();



        public void Share(string platform)
        {
            Console.WriteLine($"Post shared to {platform}!");
        }
    }
}
