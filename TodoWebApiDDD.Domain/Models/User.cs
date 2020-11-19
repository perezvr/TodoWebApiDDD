using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoWebApiDDD.Domain.Models
{
    public class User : BaseModel
    {
        private User() { }
        public User(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        [Required]
        public string Name { get; private set; }
        [Required]
        public string Email { get; private set; }
        [Required]
        public string Password { get; private set; }

        public List<Task> Tasks { get; private set; }

        public void UpdateData(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
