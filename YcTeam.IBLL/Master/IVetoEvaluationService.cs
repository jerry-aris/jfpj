using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YcTeam.IBLL.Master
{
    public interface IVetoEvaluationService
    {
        Task CreateVetoEvaluation(string project, string vetoCondition, string vetoContent);

        Task EditVetoEvaluation(Guid id, string project, string vetoCondition, string vetoContent);

        Task RemoveVetoEvaluation(Guid id);

        Task<List<DTO.Master.VetoEvaluationDto>> GetAllVetoEvaluation(int pageSize, int pageIndex, bool asc);

        Task<int> GetDataCount();
        Task<bool> ExistsVetoEvaluation(Guid id);


    }
}
