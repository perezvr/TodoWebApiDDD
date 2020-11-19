using System.Collections.Generic;
using TodoWebApiDDD.Application.DTO.DTO;

namespace TodoWebApiDDD.Application.Interfaces
{
    public interface IUserApplicationService
    {
        UserDTO Add(UserDTO obj);
        UserDTO Update(int id, UserDTO obj);
        void Delete(int id);
        IEnumerable<UserDTO> Get();
        UserDTO Get(int id);
    }
}
