using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using YcTeam.DAL.System;
using YcTeam.DAL.WorkFlow;
using YcTeam.IBLL.Master;
using YcTeam.IBLL.System;
using YcTeam.IBLL.WorkFlow;
using YcTeam.IDAL.System;
using YcTeam.Models;
using YcTeam.Models.Sys;
using YcTeam.Models.WorkFlow;

namespace YcTeam.BLL.WorkFlow
{
    public class FlowInstanceService : IFlowInstanceService
    {
        /// <summary>
        /// 创建工作流实例
        /// </summary>
        /// <returns></returns>
        public async Task CreateFlowInstance(FlowInstance flowInstance)
        {
            using (var flowInstanceDao = new FlowInstanceDao())
            {
                await flowInstanceDao.CreateAsync(flowInstance);
            }
        }

        public async Task<List<FlowInstance>> GetAllFlowInstance()
        {
            using (var flowInstanceDao = new FlowInstanceDao())
            {
                return await flowInstanceDao.GetAllAsync().ToListAsync();
            }
        }
    }
}
