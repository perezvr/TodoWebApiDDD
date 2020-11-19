using TodoWebApiDDD.Domain.Core.Interfaces.Repositories;
using TodoWebApiDDD.Domain.Core.Interfaces.Services;
using TodoWebApiDDD.Domain.Models;

namespace TodoWebApiDDD.Domain.Service.Services
{
    public class TodoListService : ServiceBase<TodoList>, ITodoListService
    {
        private readonly ITodoListRepository _todoListRepository;

        public TodoListService(ITodoListRepository todoListRepository)
            : base(todoListRepository)
        {
            _todoListRepository = todoListRepository;
        }
    }
}
