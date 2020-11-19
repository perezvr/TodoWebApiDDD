using System.Collections.Generic;
using TodoWebApiDDD.Application.DTO.DTO;

namespace TodoWebApiDDD.Application.Interfaces
{
    public interface ITodoListApplicationService
    {
        TodoListDTO Add(TodoListDTO obj);
        TodoListDTO Update(int id, TodoListDTO obj);
        void Delete(int id);
        IEnumerable<TodoListDTO> Get();
        TodoListDTO Get(int id);
    }
}
