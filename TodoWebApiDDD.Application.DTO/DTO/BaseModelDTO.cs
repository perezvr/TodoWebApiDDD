using System.Runtime.Serialization;

namespace TodoWebApiDDD.Application.DTO.DTO
{
    [DataContract]
    public abstract class BaseModelDTO
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

    }
}
