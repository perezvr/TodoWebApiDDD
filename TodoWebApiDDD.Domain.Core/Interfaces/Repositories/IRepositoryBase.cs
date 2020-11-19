using System.Collections.Generic;
using TodoWebApiDDD.Domain.Models;

namespace TodoWebApiDDD.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : BaseModel
    {
        void Add(T t);
        void Update(T t);
        void Delete(T obj);
        IEnumerable<T> Get();
        T Get(int id);
    }
}
