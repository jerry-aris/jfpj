using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YcTeam.DAL.Master;
using YcTeam.DTO.Master;
using YcTeam.IBLL.Master;
using YcTeam.Models.Master;

namespace YcTeam.BLL.Master
{
     public class ContributeService: IContributeService
    {
        public async Task<ContributeDto> GetOneContributeById(Guid contributeId)
        {
            using (IDAL.Master.IContributeDao contributeDto = new ContributeDao())
            {
                return await contributeDto.GetAllAsync()
                    .Where(m => m.Id == contributeId)
                    .Select(m => new DTO.Master.ContributeDto()
                    {
                        Id = m.Id,
                        AddPointProject = m.AddPointProject,
                        AddPointContent = m.AddPointContent,
                        AddPointMethod = m.AddPointMethod,
                        SelfPoint = m.SelfPoint,
                        SelfReason = m.SelfReason,
                        AuditPoint = m.AuditPoint,
                        CreateTime = m.CreateTime,
                    }).FirstAsync();
            }
        }
        public async Task EditContribute(Guid id, string addPointProject, string addPointContent, string addPointMethod,int selfPoint, string selfReason,int auditPoint)
        {
            using (var contributeDao = new ContributeDao())
            {
                var contribute = await contributeDao.GetOneByIdAsync(id);
                contribute.AddPointProject = addPointProject;
                contribute.AddPointContent = addPointContent;
                contribute.AddPointMethod = addPointMethod;
                contribute.SelfPoint = selfPoint;
                contribute.SelfReason = selfReason;
                contribute.AuditPoint = auditPoint;

                await contributeDao.EditAsync(contribute);
            }
        }

        public async Task CreateContribute(string addPointProject, string addPointContent, string addPointMethod, int selfPoint, string selfReason, int auditPoint)
        {
            using (var contributeDao = new ContributeDao())
            {
                await contributeDao.CreateAsync(new Contribute()
                {
                    AddPointProject = addPointProject,
                    AddPointContent = addPointContent,
                    AddPointMethod = addPointMethod,
                    SelfPoint = selfPoint,
                    SelfReason = selfReason,
                    AuditPoint = auditPoint,
                    

                });
            }
        }




        public async Task<bool> ExistsContribute(Guid id)
        {
            using (IDAL.Master.IContributeDao materialDao = new ContributeDao())
            {
                return await materialDao.GetAllAsync().AnyAsync(m => m.Id == id);
            }
        }

        public async Task<List<DTO.Master.ContributeDto>> GetAllContribute(int pageIndex = 1, int pageSize = 10, bool asc = true)
        {
            using (var contributeDao = new ContributeDao())
            {
                return await contributeDao.GetAllByPageOrderAsync(pageIndex - 1, pageSize, asc).Select(m => new DTO.Master.ContributeDto()
                {
                    Id = m.Id,
                    AddPointProject = m.AddPointProject,
                    AddPointContent = m.AddPointContent,
                    AddPointMethod = m.AddPointMethod,
                    SelfPoint = m.SelfPoint,
                    SelfReason = m.SelfReason,
                    AuditPoint = m.AuditPoint,
                    CreateTime = m.CreateTime,
                }).ToListAsync();
            }
        }


        public async Task<int> GetDataCount()
        {
            using (var contributeDao = new ContributeDao())
            {
                return await contributeDao.GetAllAsync().CountAsync();
            }
        }



        public async Task RemoveContribute(Guid id)
        {
            using (var contributeDao = new ContributeDao())
            {
                await contributeDao.RemoveAsync(id);
            }
        }
    }
}
