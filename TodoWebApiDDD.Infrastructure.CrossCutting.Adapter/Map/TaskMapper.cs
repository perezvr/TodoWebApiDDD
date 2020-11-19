using System.Collections.Generic;
using TodoWebApiDDD.Application.DTO.DTO;
using TodoWebApiDDD.Domain.Models;
using TodoWebApiDDD.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace TodoWebApiDDD.Infrastructure.CrossCutting.Adapter.Map
{
    public class TaskMapper : ITaskMapper
    {
        private readonly ITodoListMapper _todoListMapper;
        private readonly IUserMapper _userMapper;

        public TaskMapper(ITodoListMapper todoListMapper, IUserMapper userMapper)
        {
            _todoListMapper = todoListMapper;
            _userMapper = userMapper;
        }

        public IEnumerable<TaskDTO> MapperToListDTO(IEnumerable<Task> tasks)
        {
            List<TaskDTO> tasksDTO = new List<TaskDTO>();

            foreach (var Task in tasks)
                tasksDTO.Add(MapperToDTO(Task));

            return tasksDTO;
        }

        public TaskDTO MapperToDTO(Task task) => task != null ? new TaskDTO(task.Id, task.Name, task.Done, _todoListMapper.MapperToDTO(task.TodoList), _userMapper.MapperToDTO(task.User)) : null;

        public Task MapperToEntity(TaskDTO taskDTO) => new Task(taskDTO.Id, taskDTO.Name, taskDTO.Done, _todoListMapper.MapperToEntity(taskDTO.TodoList), _userMapper.MapperToEntity(taskDTO.User));
    }
}
