using System.Runtime.Serialization;

namespace TodoWebApiDDD.Application.DTO.DTO
{
    [DataContract]
    public class TodoListDTO : BaseModelDTO
    {
        public TodoListDTO() { }
        public TodoListDTO(int id, string name, bool done, CategoryDTO category)
        {
            Id = id;
            Name = name;
            Done = done;
            Category = category;
        }

        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "done")]
        public bool Done { get; set; }

        [DataMember(Name = "category")]
        public CategoryDTO Category { get; set; }
    }
}
