using System.Runtime.Serialization;

namespace TodoWebApiDDD.Application.DTO.DTO
{
    [DataContract]
    public class CategoryDTO : BaseModelDTO
    {
        public CategoryDTO() { }

        public CategoryDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
