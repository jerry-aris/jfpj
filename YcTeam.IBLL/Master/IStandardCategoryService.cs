using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YcTeam.IBLL.Master
{
    public interface IStandardCategoryService
    {

        Task CreateStandardCategory(string name, int categoryCode);

        Task EditStandardCategory(Guid id, string name, int categoryCode);

        Task<List<DTO.Master.StandardCategoryDto>> GetAllStandardCategory(int pageSize, int pageIndex, bool asc);

        Task RemoveStandardCategory(Guid id);

        Task<int> GetDataCount();
        Task<bool> ExistsStandardCategory(Guid id);
    }
}
