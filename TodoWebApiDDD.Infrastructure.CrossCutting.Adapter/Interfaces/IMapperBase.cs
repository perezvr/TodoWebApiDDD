using System.Collections.Generic;
using TodoWebApiDDD.Application.DTO.DTO;
using TodoWebApiDDD.Domain.Models;

namespace TodoWebApiDDD.Infrastructure.CrossCutting.Adapter.Interfaces
{
    public interface IMapperBase<TModel, TDTO> where TModel : BaseModel where TDTO : BaseModelDTO
    {
        TModel MapperToEntity(TDTO tDTO);

        IEnumerable<TDTO> MapperToListDTO(IEnumerable<TModel> tModel);

        TDTO MapperToDTO(TModel tModel);
    }
}
