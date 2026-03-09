using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Abstractions
{
    /// <summary>
    /// Хуваалцах боломжтой объектыг төлөөлөх интерфейс.
    /// </summary>
    public interface ISharable
    {
        void Share(string platform);
    }
}
