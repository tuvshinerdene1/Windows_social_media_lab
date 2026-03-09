using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.SocialMedia.Lib.Abstractions
{
    /// <summary>
    /// Зааж өгсөн төрлийн объектуудыг удирдах үндсэн репозиторийн интерфейс.
    /// </summary>
    /// <typeparam name="T">Репогийн объектийн төрөл</typeparam>
    public interface IRepository<T>
    {
        void add(T entity);
        IEnumerable<T> GetAll();
        T GetById(Guid id);
    }
}
