using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Models.Base
{
    public abstract class ContentBase : BaseEntity
    {
        public string authorId { get; set; }
        public string Content { get; set; }
    }
}
