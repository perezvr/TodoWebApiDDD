using System.Collections.Generic;
using TodoWebApiDDD.Application.DTO.DTO;
using TodoWebApiDDD.Application.Interfaces;
using TodoWebApiDDD.Domain.Core.Interfaces.Services;
using TodoWebApiDDD.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace TodoWebApiDDD.Application.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserService _userService;
        private readonly IUserMapper _userMapper;

        public UserApplicationService(IUserService userService, IUserMapper userMapper)
        {
            _userService = userService;
            _userMapper = userMapper;
        }

        public UserDTO Add(UserDTO userDTO)
        {
            var user = _userMapper.MapperToEntity(userDTO);
            return _userMapper.MapperToDTO(_userService.Add(user));
        }

        public UserDTO Update(int id, UserDTO userDTO)
        {
            var user = _userService.Get(id);
            user.UpdateData(userDTO.Name, userDTO.Email, userDTO.Password);
            return _userMapper.MapperToDTO(_userService.Update(user));
        }

        public void Delete(int id) => _userService.Delete(_userService.Get(id));

        public IEnumerable<UserDTO> Get()
        {
            var users = _userService.Get();
            return _userMapper.MapperToListDTO(users);
        }

        public UserDTO Get(int id)
        {
            var user = _userService.Get(id);
            return _userMapper.MapperToDTO(user);
        }
    }
}
