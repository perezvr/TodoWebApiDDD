using TodoWebApiDDD.Domain.Core.Interfaces.Repositories;
using TodoWebApiDDD.Domain.Core.Interfaces.Services;
using TodoWebApiDDD.Domain.Models;

namespace TodoWebApiDDD.Domain.Service.Services
{
    public class TaskService : ServiceBase<Task>, ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
            : base(taskRepository)
        {
            _taskRepository = taskRepository;
        }
    }
}
