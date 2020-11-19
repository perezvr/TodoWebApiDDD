using System.Collections.Generic;
using TodoWebApiDDD.Application.DTO.DTO;
using TodoWebApiDDD.Application.Interfaces;
using TodoWebApiDDD.Domain.Core.Interfaces.Services;
using TodoWebApiDDD.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace TodoWebApiDDD.Application.Services
{
    public class TodoListApplicationService : ITodoListApplicationService
    {
        private readonly ITodoListService _todoListService;
        private readonly ICategoryService _categoryService;
        private readonly ITodoListMapper _todoListMapper;

        public TodoListApplicationService(ITodoListService todoListService, ITodoListMapper todoListMapper, ICategoryService categoryService)
        {
            _todoListService = todoListService;
            _todoListMapper = todoListMapper;
            _categoryService = categoryService;
        }

        public TodoListDTO Add(TodoListDTO todoListDTO)
        {
            var todoList = _todoListMapper.MapperToEntity(todoListDTO);
            todoList.SetCategory(_categoryService.Get(todoList.Category.Id));
            return _todoListMapper.MapperToDTO(_todoListService.Add(todoList));
        }

        public TodoListDTO Update(int id, TodoListDTO todoListDTO)
        {
            var todoList = _todoListService.Get(id);
            todoList.UpdateData(todoListDTO.Name, todoListDTO.Done, _categoryService.Get(todoListDTO.Category.Id));
            return _todoListMapper.MapperToDTO(_todoListService.Update(todoList));
        }

        public void Delete(int id) => _todoListService.Delete(_todoListService.Get(id));

        public IEnumerable<TodoListDTO> Get()
        {
            var todoLists = _todoListService.Get();
            return _todoListMapper.MapperToListDTO(todoLists);
        }

        public TodoListDTO Get(int id)
        {
            var todoList = _todoListService.Get(id);
            return _todoListMapper.MapperToDTO(todoList);
        }
    }
}
