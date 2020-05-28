using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using YcTeam.DAL.System;
using YcTeam.IBLL.Master;
using YcTeam.IBLL.System;
using YcTeam.IDAL.System;
using YcTeam.Models;
using YcTeam.Models.Sys;

namespace YcTeam.BLL.System
{
    public class SysDepartService : ISysDepartService
    {
        /// <summary>
        /// 查询角色
        /// </summary>
        /// <param name="sysDepartId"></param>
        /// <returns></returns>
        public async Task<DTO.System.SysDepartDto> GetOneSysDepartById(Guid sysDepartId)
        {
            using (IDAL.System.ISysDepartDao sysDepartDao = new SysDepartDao())
            {
                return await sysDepartDao.GetAllAsync()
                    .Where(m => m.Id == sysDepartId)
                    .Select(m => new DTO.System.SysDepartDto()
                    {
                        Id = m.Id,
                        DepartName = m.DepartName,
                        RegionCounty = m.RegionCounty,
                        RegionCity = m.RegionCity,
                        CreateTime = m.CreateTime,
                    }).FirstAsync();
            }
        }

        /// <summary>
        /// 创建角色
        /// </summary>
        /// <param name="departName"></param>
        /// <param name="regionCity"></param>
        /// <param name="regionCounty"></param>
        /// <returns></returns>
        public async Task CreateSysDepart(string departName, string regionCity, string regionCounty)
        {
            using (var sysDepartDao = new SysDepartDao())
            {
                await sysDepartDao.CreateAsync(new SysDepart()
                {
                    DepartName = departName,
                    RegionCity = regionCity,
                    RegionCounty = regionCounty
                });
            }
        }

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="sysDepartId"></param>
        /// <param name="departName"></param>
        /// <param name="regionCity"></param>
        /// <param name="regionCounty"></param>
        /// <returns></returns>
        public async Task EditSysDepart(Guid sysDepartId, string departName, string regionCity, string regionCounty)
        {
            using (var sysDepartDao = new SysDepartDao())
            {
                var sysDepart = await sysDepartDao.GetOneByIdAsync(sysDepartId);
                sysDepart.DepartName = departName;
                sysDepart.RegionCity = regionCity;
                sysDepart.RegionCounty = regionCounty;
                await sysDepartDao.EditAsync(sysDepart);
            }
        }

        /// <summary>
        /// 判断角色存在
        /// </summary>
        /// <param name="sysDepartId">用户角色主键</param>
        /// <returns></returns>
        public async Task<bool> ExistsSysDepart(Guid sysDepartId)
        {
            using (IDAL.System.ISysDepartDao sysDepartDao = new SysDepartDao())
            {
                return await sysDepartDao.GetAllAsync().AnyAsync(m => m.Id == sysDepartId);
            }
        }

        public async Task RemoveSysDepart(Guid id)
        {
            using (var sysDepartDao = new SysDepartDao())
            {
                await sysDepartDao.RemoveAsync(id);
            }
        }

        /// <summary>
        /// 角色查询
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        public async Task<List<DTO.System.SysDepartDto>> GetAllSysDepart(int pageIndex = 1,int pageSize = 10, bool asc = true)
        {
            using (var sysDepartDao = new SysDepartDao())
            {
                return await sysDepartDao.GetAllByPageOrderAsync(pageIndex - 1, pageSize,asc).Select(m => new DTO.System.SysDepartDto()
                {
                    Id = m.Id,
                    RegionCity = m.RegionCity,
                    RegionCounty = m.RegionCounty,
                    DepartName = m.DepartName,
                    CreateTime = m.CreateTime
                }).ToListAsync();
            }
        }

        public async Task<int> GetDataCount()
        {
            using (var sysDepartDao = new SysDepartDao())
            {
                return await sysDepartDao.GetAllAsync().CountAsync();
            }
        }
    }
}
