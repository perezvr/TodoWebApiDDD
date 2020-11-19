using System.Collections.Generic;
using TodoWebApiDDD.Application.DTO.DTO;
using TodoWebApiDDD.Application.Interfaces;
using TodoWebApiDDD.Domain.Core.Interfaces.Services;
using TodoWebApiDDD.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace TodoWebApiDDD.Application.Services
{
    public class TaskApplicationService : ITaskApplicationService
    {
        private readonly ITaskService _taskService;
        private readonly ITaskMapper _taskMapper;
        private readonly ITodoListService _todoListService;
        private readonly IUserService _userService;

        public TaskApplicationService(ITaskService taskService, ITaskMapper taskMapper, ITodoListService todoListService, IUserService userService)
        {
            _taskService = taskService;
            _taskMapper = taskMapper;

            _todoListService = todoListService;
            _userService = userService;
        }

        public TaskDTO Add(TaskDTO taskDTO)
        {
            var task = _taskMapper.MapperToEntity(taskDTO);
            task.SetTodoList(_todoListService.Get(taskDTO.TodoList.Id));
            task.SetUser(_userService.Get(taskDTO.User.Id));
            return _taskMapper.MapperToDTO(_taskService.Add(task));
        }

        public TaskDTO Update(int id, TaskDTO taskDTO)
        {
            var task = _taskService.Get(id);
            task.UpdateData(taskDTO.Name, taskDTO.Done, _todoListService.Get(taskDTO.TodoList.Id), _userService.Get(taskDTO.User.Id));
            return _taskMapper.MapperToDTO(_taskService.Update(task));
        }

        public void Delete(int id) => _taskService.Delete(_taskService.Get(id));

        public IEnumerable<TaskDTO> Get()
        {
            var tasks = _taskService.Get();
            return _taskMapper.MapperToListDTO(tasks);
        }

        public TaskDTO Get(int id)
        {
            var task = _taskService.Get(id);
            return _taskMapper.MapperToDTO(task);
        }
    }
}
