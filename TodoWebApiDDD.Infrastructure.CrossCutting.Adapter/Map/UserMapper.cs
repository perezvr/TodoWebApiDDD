using System.Collections.Generic;
using TodoWebApiDDD.Application.DTO.DTO;
using TodoWebApiDDD.Domain.Models;
using TodoWebApiDDD.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace TodoWebApiDDD.Infrastructure.CrossCutting.Adapter.Map
{
    public class UserMapper : IUserMapper
    {
        public IEnumerable<UserDTO> MapperToListDTO(IEnumerable<User> users)
        {
            List<UserDTO> usersDTO = new List<UserDTO>();

            foreach (var user in users)
                usersDTO.Add(MapperToDTO(user));

            return usersDTO;
        }

        public UserDTO MapperToDTO(User user) => user != null ? new UserDTO(user.Id, user.Name, user.Email, user.Password) : null;

        public User MapperToEntity(UserDTO userDTO) => userDTO != null ? new User(userDTO.Id, userDTO.Name, userDTO.Email, userDTO.Password) : null;
    }
}
