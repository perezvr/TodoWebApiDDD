using System;

namespace TodoWebApiDDD.Infrastructure.Data.Interfaces
{
    public interface IDataService
    {
        public void InitializeDB(IServiceProvider serviceProvider);
    }
}
