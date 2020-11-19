using System.Collections.Generic;
using TodoWebApiDDD.Application.DTO.DTO;
using TodoWebApiDDD.Domain.Models;
using TodoWebApiDDD.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace TodoWebApiDDD.Infrastructure.CrossCutting.Adapter.Map
{
    public class TodoListMapper : ITodoListMapper
    {
        private readonly ICategoryMapper _categoryMapper;

        public TodoListMapper(ICategoryMapper categoryMapper)
        {
            _categoryMapper = categoryMapper;
        }

        public IEnumerable<TodoListDTO> MapperToListDTO(IEnumerable<TodoList> todoLists)
        {
            List<TodoListDTO> todoListsDTO = new List<TodoListDTO>();

            foreach (var todoList in todoLists)
                todoListsDTO.Add(MapperToDTO(todoList));

            return todoListsDTO;
        }

        public TodoListDTO MapperToDTO(TodoList todoList) => todoList != null ? new TodoListDTO(todoList.Id, todoList.Name, todoList.Done, _categoryMapper.MapperToDTO(todoList.Category)) : null;

        public TodoList MapperToEntity(TodoListDTO todoListDTO) => new TodoList(todoListDTO.Id, todoListDTO.Name, todoListDTO.Done, _categoryMapper.MapperToEntity(todoListDTO.Category));
    }
}
