using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoWebApiDDD.Domain.Models
{
    public class TodoList : BaseModel
    {
        private TodoList() { }
        public TodoList(int id, string name, bool done, Category category)
        {
            Id = id;
            Name = name;
            Done = done;
            Category = category;

            Tasks = new List<Task>();
        }

        [Required]
        public string Name { get; private set; }
        [Required]
        public bool Done { get; private set; }

        [Required]
        public Category Category { get; private set; }

        public List<Task> Tasks { get; private set; }

        public void UpdateData(string name, bool done, Category category)
        {
            Name = name;
            Done = done;
            Category = category;
        }

        public void SetCategory(Category category) => Category = category;
    }
}
