using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Abstractions
{
    public  interface IRepository<T>
    {
        void add(T entity);
        IEnumerable<T> GetAll();
        T GetById(Guid id);
    }
}
