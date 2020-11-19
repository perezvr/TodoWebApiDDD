using System.Collections.Generic;
using TodoWebApiDDD.Application.DTO.DTO;

namespace TodoWebApiDDD.Application.Interfaces
{
    public interface ICategoryApplicationService
    {
        CategoryDTO Add(CategoryDTO obj);
        CategoryDTO Update(int id, CategoryDTO obj);
        void Delete(int id);
        IEnumerable<CategoryDTO> Get();
        CategoryDTO Get(int id);
    }
}
