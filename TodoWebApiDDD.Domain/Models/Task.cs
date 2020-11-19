using System.ComponentModel.DataAnnotations;

namespace TodoWebApiDDD.Domain.Models
{
    public class Task : BaseModel
    {
        private Task() { }

        public Task(int id, string name, bool done, TodoList todoList, User user)
        {
            Id = id;
            Name = name;
            Done = done;
            TodoList = todoList;
            User = user;
        }

        [Required]
        public string Name { get; private set; }
        [Required]
        public bool Done { get; private set; }

        [Required]
        public TodoList TodoList { get; private set; }
        [Required]
        public User User { get; private set; }

        public void UpdateData(string name, bool done, TodoList todoList, User user)
        {
            Name = name;
            Done = done;
            TodoList = todoList;
            User = user;
        }

        public void SetTodoList(TodoList todoList) => TodoList = todoList;

        public void SetUser(User user) => User = user;
    }
}
