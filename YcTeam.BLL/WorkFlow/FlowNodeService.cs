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
    public class FlowNodeService : IFlowNodeService
    {
        public async Task CreateFlowNode(FlowNode flowNode)
        {
            using (var flowNodeDao = new FlowNodeDao())
            {
                await flowNodeDao.CreateAsync(flowNode);
            }
        }

        /// <summary>
        /// 创建工作流节点
        /// </summary>
        /// <returns></returns>

        public async Task<FlowNode> GetFlowNodeByNodeName(string nodeName)
        {
            using (var flowNodeDao = new FlowNodeDao())
            {
                return await flowNodeDao.GetAllAsync()
                    .Where(m => m.NodeName.Equals(nodeName)).FirstAsync();
            }
        }

        public async Task<List<FlowNode>> GetAllFlowNode()
        {
            using (var flowNodeDao = new FlowNodeDao())
            {
                return await flowNodeDao.GetAllAsync().ToListAsync();
            }
        }
    }
}
