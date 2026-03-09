using SocialMedia.SocialMedia.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Abstractions
{
    /// <summary>
    /// Коммент бичих боломжтой объектыг төлөөлөх интерфейс.
    /// </summary>
    /// <remarks>Комментийн жагсаалтыг удирдах боломжтой.</remarks>
    public interface ICommentable
    {
        List <Comment> Comments { get; set; }
    }
}
