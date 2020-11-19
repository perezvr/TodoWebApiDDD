using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TodoWebApiDDD.Domain.Core.Interfaces.Repositories;
using TodoWebApiDDD.Domain.Models;
using TodoWebApiDDD.Infrastructure.Data;

namespace TodoWebApiDDD.Infrastructure.Repository
{
    public class TodoListRepository : RepositoryBase<TodoList>, ITodoListRepository
    {
        private readonly ApplicationContext _context;

        public TodoListRepository(ApplicationContext context)
            : base(context)
        {
            _context = context;
        }

        public override IEnumerable<TodoList> Get()
        {
            return DbSet.Include(t => t.Category).ToList();
        }

        public override TodoList Get(int id)
        {
            return DbSet.Include(t => t.Category)
                .SingleOrDefault(t => t.Id.Equals(id));
        }
    }
}
