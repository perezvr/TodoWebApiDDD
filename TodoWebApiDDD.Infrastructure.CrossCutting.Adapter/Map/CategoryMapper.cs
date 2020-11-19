using System.Collections.Generic;
using TodoWebApiDDD.Application.DTO.DTO;
using TodoWebApiDDD.Domain.Models;
using TodoWebApiDDD.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace TodoWebApiDDD.Infrastructure.CrossCutting.Adapter.Map
{
    public class CategoryMapper : ICategoryMapper
    {
        public IEnumerable<CategoryDTO> MapperToListDTO(IEnumerable<Category> categories)
        {
            List<CategoryDTO> categoriesDTO = new List<CategoryDTO>();

            foreach (var category in categories)
                categoriesDTO.Add(MapperToDTO(category));

            return categoriesDTO;
        }

        public CategoryDTO MapperToDTO(Category category) => category != null ? new CategoryDTO(category.Id, category.Name) : null;

        public Category MapperToEntity(CategoryDTO categoryDTO) => categoryDTO != null ? new Category(categoryDTO.Id, categoryDTO.Name) : null;
    }
}
