using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using TodoWebApiDDD.Infrastructure.Data.Interfaces;


namespace TodoWebApiDDD.Infrastructure.Data
{
    public class DataService : IDataService
    {
        public void InitializeDB(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationContext>();
            context.Database.Migrate();
        }
    }
}
