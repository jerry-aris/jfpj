using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using YcTeam.IDAL.Master;
using YcTeam.DTO.Master;
using YcTeam.IBLL.Master;
using YcTeam.Models;
using YcTeam.Models.Master;

namespace YcTeam.BLL.Master
{
    public class ProjectService : IProjectService
    {
        public async Task<DTO.Master.ProjectDto> GetOneProjectById(Guid projectId)
        {
            using (IDAL.Master.IProjectDao projectDao = new ProjectDao())
            {
                return await projectDao.GetAllAsync()
                    .Where(m => m.Id == projectId)
                    .Select(m => new DTO.Master.ProjectDto()
                    {
                        Name = m.Name,
                       
                        CreateTime = m.CreateTime,
                    }).FirstAsync();
            }
        }
        public async Task CreateProject(string name)
        {
            using (var projectDao = new ProjectDao())
            {
                await projectDao.CreateAsync(new Project()
                {
                    Name = name,
                    
            });
            }
        }

        public async Task EditProject(Guid projectId, string name)
        {
            using (var projectDao = new ProjectDao())
            {
                var project = await projectDao.GetOneByIdAsync(projectId);
                project.Name = name;
              
                await projectDao.EditAsync(project);
            }
        }

        public async Task<bool> ExistsProject(Guid projectId)
        {
            using (IDAL.Master.IProjectDao projectDao = new ProjectDao())
            {
                return await projectDao.GetAllAsync().AnyAsync(m => m.Id == projectId);
            }
        }

        public async Task<List<ProjectDto>> GetAllProject(int pageIndex, int pageSize, bool asc = true)
        {
            using (var projectDao = new ProjectDao())
            {
                return await projectDao.GetAllByPageOrderAsync(pageIndex - 1, pageSize, asc).Select(m => new DTO.Master.ProjectDto()
                {
                    Id=m.Id,
                    Name = m.Name,
                    
                    CreateTime = m.CreateTime,
                }).ToListAsync();
            }
        }

        public async Task<int> GetDataCount()
        {
            using (var projectDao = new ProjectDao())
            {
                return await projectDao.GetAllAsync().CountAsync();
            }
        }

       
        

        public async Task RemoveProject(Guid id)
        {
            using (var projectDao = new ProjectDao())
            {
                await projectDao.RemoveAsync(id);
            }
        }
    }
}
