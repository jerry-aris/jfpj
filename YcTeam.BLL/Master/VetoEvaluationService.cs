using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using YcTeam.DAL.Master;
using YcTeam.IDAL.Master;
using YcTeam.DTO.Master;
using YcTeam.IBLL.Master;
using YcTeam.Models.Master;

namespace YcTeam.BLL.Master
{
    public class VetoEvaluationService : IVetoEvaluationService
    {
        public async Task<DTO.Master.VetoEvaluationDto> GetOneVetoEvaluationById(Guid id)
        {
            using (IDAL.Master.IVetoEvaluationDao vetoEvaluationDao = new VetoEvaluationDao())
            {
                return await vetoEvaluationDao.GetAllAsync()
                    .Where(m => m.Id == id)
                    .Select(m => new DTO.Master.VetoEvaluationDto()
                    {
                        Id = m.Id,
                        Project = m.Project,
                        VetoCondition = m.VetoCondition,
                        VetoContent = m.VetoContent,
                        CreateTime = m.CreateTime,
                    }).FirstAsync();
            }
        }
        public async Task CreateVetoEvaluation(string project, string vetoCondition, string vetoContent)
        {
            using (var vetoEvaluationDao = new VetoEvaluationDao())
            {
                await vetoEvaluationDao.CreateAsync(new VetoEvaluation()
                {
                    Project = project,
                    VetoCondition = vetoCondition,
                    VetoContent = vetoContent,
                    });
            }
        }

      


        public async Task EditVetoEvaluation(Guid id, string project, string vetoCondition, string vetoContent)
        {
            using (var vetoEvaluationDao = new VetoEvaluationDao())
            {
                var vetoEvaluation = await vetoEvaluationDao.GetOneByIdAsync(id);
                vetoEvaluation.Project = project;
                vetoEvaluation.VetoCondition = vetoCondition;
                vetoEvaluation.VetoContent = vetoContent;
                await vetoEvaluationDao.EditAsync(vetoEvaluation);

            }
        }

        public async Task<bool> ExistsVetoEvaluation(Guid vetoEvaluationId)
        {
            using (IDAL.Master.IVetoEvaluationDao vetoEvaluationDao = new VetoEvaluationDao())
            {
                return await vetoEvaluationDao.GetAllAsync().AnyAsync(m => m.Id == vetoEvaluationId);
            }
        }

        public async Task<List<VetoEvaluationDto>> GetAllVetoEvaluation(int pageIndex, int pageSize, bool asc = true)
        {
            using (var vetoEvaluationDao = new VetoEvaluationDao())
            {
                return await vetoEvaluationDao.GetAllByPageOrderAsync(pageIndex - 1, pageSize, asc).Select(m => new DTO.Master.VetoEvaluationDto()
                {
                    Id = m.Id,
                    Project = m.Project,
                    VetoCondition = m.VetoCondition,
                    VetoContent = m.VetoContent,
                    CreateTime = m.CreateTime,
                }).ToListAsync();
            }
        }

        public async Task<int> GetDataCount()
        {
            using (var vetoEvaluationDao = new VetoEvaluationDao())
            {
                return await vetoEvaluationDao.GetAllAsync().CountAsync();
            }
        }

        public async Task RemoveVetoEvaluation(Guid id)
        {
            using (var vetoEvaluationDao = new VetoEvaluationDao())
            {
                await vetoEvaluationDao.RemoveAsync(id);
            }
        }
    }
}
