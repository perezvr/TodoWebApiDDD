using Microsoft.EntityFrameworkCore;
using TodoWebApiDDD.Domain.Models;

namespace TodoWebApiDDD.Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<TodoList> TodoList { get; set; }
        public DbSet<Task> Task { get; set; }
    }
}
