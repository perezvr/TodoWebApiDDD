using TodoWebApiDDD.Application.DTO.DTO;
using TodoWebApiDDD.Domain.Models;

namespace TodoWebApiDDD.Infrastructure.CrossCutting.Adapter.Interfaces
{
    public interface ICategoryMapper : IMapperBase<Category, CategoryDTO> { }
}
