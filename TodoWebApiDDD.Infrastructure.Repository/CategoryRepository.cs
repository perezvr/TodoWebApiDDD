using TodoWebApiDDD.Domain.Core.Interfaces.Repositories;
using TodoWebApiDDD.Domain.Models;
using TodoWebApiDDD.Infrastructure.Data;

namespace TodoWebApiDDD.Infrastructure.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        private readonly ApplicationContext _context;

        public CategoryRepository(ApplicationContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
