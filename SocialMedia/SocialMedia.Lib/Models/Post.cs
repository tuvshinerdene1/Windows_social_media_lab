using SocialMedia.SocialMedia.Lib.Abstractions;
using SocialMedia.SocialMedia.Lib.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Models
{
    public class Post : ContentBase, Ilikeable, ISharable
    {
        public int LikeCount { get; set; }

        public void Like()
        {
            LikeCount++;
            Console.WriteLine("Post liked!");
        }

        public void Share(string platform)
        {
            Console.WriteLine($"Post shared to {platform}!");
        }
    }
}
