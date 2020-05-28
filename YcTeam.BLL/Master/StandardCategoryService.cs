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
    
        public class StandardCategoryService : IStandardCategoryService
        {
            public async Task<DTO.Master.StandardCategoryDto> GetOneStandardCategoryById(Guid id)
            {
                using (IDAL.Master.IStandardCategoryDao standardCategoryDao = new StandardCategoryDao())
                {
                    return await standardCategoryDao.GetAllAsync()
                        .Where(m => m.Id == id)
                        .Select(m => new DTO.Master.StandardCategoryDto()
                        {
                            Name = m.Name,
                            CategoryCode = m.CategoryCode,
                            CreateTime = m.CreateTime,
                        }).FirstAsync();
                }
            }
            public async Task CreateStandardCategory(string name, int categoryCode)
            {
                using (var standardCategoryDao = new StandardCategoryDao())
                {
                    await standardCategoryDao.CreateAsync(new StandardCategory()
                    {
                        Name = name,
                        CategoryCode = categoryCode,
                        
                    });
                }
            }




            public async Task EditStandardCategory(Guid id, string name, int categoryCode)
            {
                using (var standardCategoryDao = new StandardCategoryDao())
                {
                    var standardCategory = await standardCategoryDao.GetOneByIdAsync(id);
                    standardCategory.Name = name;
                    standardCategory.CategoryCode = categoryCode;
                    await standardCategoryDao.EditAsync(standardCategory);

                }
            }

            public async Task<bool> ExistsStandardCategory(Guid standardCategoryId)
            {
                using (IDAL.Master.IStandardCategoryDao standardCategoryDao = new StandardCategoryDao())
                {
                    return await standardCategoryDao.GetAllAsync().AnyAsync(m => m.Id == standardCategoryId);
                }
            }

            public async Task<List<StandardCategoryDto>> GetAllStandardCategory(int pageIndex, int pageSize, bool asc = true)
            {
                using (var standardCategoryDao = new StandardCategoryDao())
                {
                    return await standardCategoryDao.GetAllByPageOrderAsync(pageIndex - 1, pageSize, asc).Select(m => new DTO.Master.StandardCategoryDto()
                    {
                        Id = m.Id,
                        Name = m.Name,
                        CategoryCode = m.CategoryCode,
                        CreateTime = m.CreateTime,
                    }).ToListAsync();
                }
            }

            public async Task<int> GetDataCount()
            {
                using (var standardCategoryDao = new StandardCategoryDao())
                {
                    return await standardCategoryDao.GetAllAsync().CountAsync();
                }
            }

            public async Task RemoveStandardCategory(Guid id)
            {
                using (var standardCategoryDao = new StandardCategoryDao())
                {
                    await standardCategoryDao.RemoveAsync(id);
                }
            }
        }
    }
