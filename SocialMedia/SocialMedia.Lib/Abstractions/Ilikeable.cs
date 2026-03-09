using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Abstractions
{
    /// <summary>
    /// Хэрэглэгчдээс лайк авах боломжтой объектыг төлөөлөх интерфейс.
    /// </summary>
    /// <remarks>Лайк дарсан хэрэглэгчдийн жагсаалтыг харах боломжтой</remarks>
    public interface  Ilikeable
    {
        List<string> LikedByUsers { get; set; }
        int LikeCount => LikedByUsers.Count;
    }
}
