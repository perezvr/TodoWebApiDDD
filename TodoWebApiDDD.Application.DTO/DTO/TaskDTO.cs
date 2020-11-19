using System.Runtime.Serialization;

namespace TodoWebApiDDD.Application.DTO.DTO
{
    [DataContract]
    public class TaskDTO : BaseModelDTO
    {
        public TaskDTO() { }
        public TaskDTO(int id, string name, bool done, TodoListDTO todoList, UserDTO user)
        {
            Id = id;
            Name = name;
            Done = done;
            TodoList = todoList;
            User = user;
        }

        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "done")]
        public bool Done { get; private set; }

        [DataMember(Name = "todolist")]
        public TodoListDTO TodoList { get; set; }
        [DataMember(Name = "user")]
        public UserDTO User { get; set; }
    }
}
