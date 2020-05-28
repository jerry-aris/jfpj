using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YcTeam.DTO.Master;

namespace YcTeam.IBLL.System
{
    public interface ISysDepartService
    {
        Task CreateSysDepart(string name, string regionCity, string regionCounty);

        Task EditSysDepart(Guid sysDepartId, string name, string regionCity, string regionCounty);

        Task<List<DTO.System.SysDepartDto>> GetAllSysDepart(int pageSize, int pageIndex, bool asc);

        Task<int> GetDataCount();

        Task RemoveSysDepart(Guid id);

        Task<bool> ExistsSysDepart(Guid sysDepartId);
    }
}
