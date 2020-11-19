using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TodoWebApiDDD.Domain.Core.Interfaces.Repositories;
using TodoWebApiDDD.Domain.Models;
using TodoWebApiDDD.Infrastructure.Data;

namespace TodoWebApiDDD.Infrastructure.Repository
{
    public class TaskRepository : RepositoryBase<Task>, ITaskRepository
    {
        private readonly ApplicationContext _context;

        public TaskRepository(ApplicationContext context)
            : base(context)
        {
            _context = context;
        }

        public override IEnumerable<Task> Get()
        {
            return DbSet
                .Include(t => t.TodoList)
                    .ThenInclude(t => t.Category)
                .Include(t => t.User).ToList();
        }

        public override Task Get(int id)
        {
            return DbSet
                .Include(t => t.TodoList)
                    .ThenInclude(t => t.Category)
                .Include(t => t.User).ToList()
                .SingleOrDefault(t => t.Id.Equals(id));
        }
    }
}
