using TodoWebApiDDD.Domain.Core.Interfaces.Repositories;
using TodoWebApiDDD.Domain.Models;
using TodoWebApiDDD.Infrastructure.Data;

namespace TodoWebApiDDD.Infrastructure.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
            : base(context)
        {
            _context = context;
        }
    }
}
