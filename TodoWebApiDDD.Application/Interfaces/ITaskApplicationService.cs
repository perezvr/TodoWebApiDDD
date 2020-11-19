using System.Collections.Generic;
using TodoWebApiDDD.Application.DTO.DTO;

namespace TodoWebApiDDD.Application.Interfaces
{
    public interface ITaskApplicationService
    {
        TaskDTO Add(TaskDTO obj);
        TaskDTO Update(int id, TaskDTO obj);
        void Delete(int id);
        IEnumerable<TaskDTO> Get();
        TaskDTO Get(int id);
    }
}
