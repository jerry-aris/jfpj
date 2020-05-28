using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YcTeam.IBLL.Master
{
    public interface IEvContentService
    {
        Task CreateEvContent(int contentCode, string content);

        Task EditEvContent(Guid id, int contentCode, string content);

        Task RemoveEvContent(Guid id);

        Task<List<DTO.Master.EvContentDto>> GetAllEvContent(int pageSize, int pageIndex, bool asc);

        Task<int> GetDataCount();

        Task<bool> ExistsEvContent(Guid id);
    }
}
