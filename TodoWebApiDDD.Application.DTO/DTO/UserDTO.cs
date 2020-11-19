using System.Runtime.Serialization;

namespace TodoWebApiDDD.Application.DTO.DTO
{
    [DataContract]
    public class UserDTO : BaseModelDTO
    {
        public UserDTO() { }

        public UserDTO(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "password")]
        public string Password { get; set; }
    }
}
