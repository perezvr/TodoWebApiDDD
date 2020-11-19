using System.Collections.Generic;
using TodoWebApiDDD.Domain.Core.Interfaces.Repositories;
using TodoWebApiDDD.Domain.Core.Interfaces.Services;
using TodoWebApiDDD.Domain.Models;

namespace TodoWebApiDDD.Domain.Service.Services
{
    public abstract class ServiceBase<T> : IServiceBase<T> where T : BaseModel
    {
        private readonly IRepositoryBase<T> _repository;

        public ServiceBase(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public T Add(T obj)
        {
            _repository.Add(obj);
            return obj;
        }

        public T Update(T obj)
        {
            _repository.Update(obj);
            return obj;
        }

        public void Delete(T obj)
        {
            _repository.Delete(obj);
        }

        public IEnumerable<T> Get()
        {
            return _repository.Get();
        }

        public T Get(int id)
        {
            return _repository.Get(id);
        }
    }
}
