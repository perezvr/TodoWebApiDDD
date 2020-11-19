using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoWebApiDDD.Domain.Models
{
    public class Category : BaseModel
    {
        private Category() { }
        public Category(int id, string name)
        {
            Id = id;
            Name = name;

            Todos = new List<TodoList>();
        }

        [Required]
        public string Name { get; private set; }

        public List<TodoList> Todos { get; private set; }

        public void UpdateData(string name)
        {
            Name = name;
        }
    }
}
