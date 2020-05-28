using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YcTeam.IBLL.Master
{
   public interface IContributeService
    {
        Task CreateContribute(string addPointProject, string addPointContent, string addPointMethod, int selfPoint, string selfReason, int auditPoint);

        Task EditContribute(Guid id, string addPointProject, string addPointContent, string addPointMethod, int selfPoint, string selfReason, int auditPoint);

        Task RemoveContribute(Guid id);

        Task<List<DTO.Master.ContributeDto>> GetAllContribute(int pageSize, int pageIndex, bool asc);

        Task<int> GetDataCount();

        Task<bool> ExistsContribute(Guid id);
    }
 
}
