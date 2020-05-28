using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using YcTeam.DAL.Master;
using YcTeam.DTO.Master;
using YcTeam.IDAL.Master;
using YcTeam.IBLL.Master;
using YcTeam.Models;
using YcTeam.Models.Master;

namespace YcTeam.BLL.Master
{
    public class EvContentService : IEvContentService
    {
        public async Task<EvContentDto> GetOneEvContentById(Guid evContentId)
        {
            using (IDAL.Master.IEvContentDao evContentDto = new EvContentDao())
            {
                return await evContentDto.GetAllAsync()
                    .Where(m => m.Id == evContentId)
                    .Select(m => new DTO.Master.EvContentDto()
                    {
                        Id = m.Id,
                        ContentCode = m.ContentCode,
                        Content = m.Content,
                        CreateTime = m.CreateTime,
                    }).FirstAsync();
            }
        }
        public async Task EditEvContent(Guid id, int contentCode, string content)
        {
            using (var evContentDao = new EvContentDao())
            {
                var evContent = await evContentDao.GetOneByIdAsync(id);
                evContent.ContentCode = contentCode;
                evContent.Content = content;
                await evContentDao.EditAsync(evContent);
            }
        }

        public async Task CreateEvContent(int contentCode, string content)
        {
            using (var evContentDao = new EvContentDao())
            {
                await evContentDao.CreateAsync(new EvContent()
                {
                    ContentCode = contentCode,
                    Content = content,
                    
                });
            }
        }

        


        public async Task<bool> ExistsEvContent(Guid id)
        {
            using (IDAL.Master.IEvContentDao evContentDao = new EvContentDao())
            {
                return await evContentDao.GetAllAsync().AnyAsync(m => m.Id == id);
            }
        }

        public async Task<List<DTO.Master.EvContentDto>> GetAllEvContent(int pageIndex = 1, int pageSize = 10, bool asc = true)
        {
            using (var evContentDao = new EvContentDao())
            {
                return await evContentDao.GetAllByPageOrderAsync(pageIndex - 1, pageSize, asc).Select(m => new DTO.Master.EvContentDto()
                {
                    Id = m.Id,
                    ContentCode = m.ContentCode,
                    Content = m.Content,
                    CreateTime = m.CreateTime
                }).ToListAsync();
            }
        }

       
        public async Task<int> GetDataCount()
        {
            using (var evContentDao = new EvContentDao())
            {
                return await evContentDao.GetAllAsync().CountAsync();
            }
        }

        

        public async Task RemoveEvContent(Guid id)
        {
            using (var evContentDao = new EvContentDao())
            {
                await evContentDao.RemoveAsync(id);
            }
        }


        
    }
}



