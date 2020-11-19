using System.Collections.Generic;
using TodoWebApiDDD.Domain.Models;

namespace TodoWebApiDDD.Domain.Core.Interfaces.Services
{
    public interface IServiceBase<T> where T : BaseModel
    {
        T Add(T t);
        T Update(T t);
        void Delete(T t);
        IEnumerable<T> Get();
        T Get(int id);
    }
}
