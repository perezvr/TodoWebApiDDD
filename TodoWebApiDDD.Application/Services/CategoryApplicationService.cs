using System.Collections.Generic;
using TodoWebApiDDD.Application.DTO.DTO;
using TodoWebApiDDD.Application.Interfaces;
using TodoWebApiDDD.Domain.Core.Interfaces.Services;
using TodoWebApiDDD.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace TodoWebApiDDD.Application.Services
{
    public class CategoryApplicationService : ICategoryApplicationService
    {
        private readonly ICategoryService _categoryService;
        private readonly ICategoryMapper _categoryMapper;

        public CategoryApplicationService(ICategoryService categoryService, ICategoryMapper categoryMapper)
        {
            _categoryService = categoryService;
            _categoryMapper = categoryMapper;
        }

        public CategoryDTO Add(CategoryDTO categoryDTO)
        {
            var category = _categoryMapper.MapperToEntity(categoryDTO);
            return _categoryMapper.MapperToDTO(_categoryService.Add(category));
        }

        public CategoryDTO Update(int id, CategoryDTO categoryDTO)
        {
            var category = _categoryService.Get(id);
            category.UpdateData(categoryDTO.Name);
            return _categoryMapper.MapperToDTO(_categoryService.Update(category));
        }

        public void Delete(int id) => _categoryService.Delete(_categoryService.Get(id));

        public IEnumerable<CategoryDTO> Get()
        {
            var categorys = _categoryService.Get();
            return _categoryMapper.MapperToListDTO(categorys);
        }

        public CategoryDTO Get(int id)
        {
            var category = _categoryService.Get(id);
            return _categoryMapper.MapperToDTO(category);
        }
    }
}
