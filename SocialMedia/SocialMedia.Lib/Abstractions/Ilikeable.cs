using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Abstractions
{
    public interface  Ilikeable
    {
        int LikeCount { get; set; }
        void Like();
    }
}
