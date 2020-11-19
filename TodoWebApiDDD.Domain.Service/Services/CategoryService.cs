using TodoWebApiDDD.Domain.Core.Interfaces.Repositories;
using TodoWebApiDDD.Domain.Core.Interfaces.Services;
using TodoWebApiDDD.Domain.Models;

namespace TodoWebApiDDD.Domain.Service.Services
{
    public class CategoryService : ServiceBase<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryrepository;
        public CategoryService(ICategoryRepository categoryrepository)
            : base(categoryrepository)
        {
            _categoryrepository = categoryrepository;
        }
    }
}
