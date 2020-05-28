using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YcTeam.IBLL.Master
{
    public interface IProjectService
    {
        Task CreateProject(string name);

        Task EditProject(Guid projectId, string name);

        Task RemoveProject(Guid id);

        Task<List<DTO.Master.ProjectDto>> GetAllProject(int pageSize, int pageIndex, bool asc);

        Task<int> GetDataCount();
        Task<bool> ExistsProject(Guid projectId);
    }
}
