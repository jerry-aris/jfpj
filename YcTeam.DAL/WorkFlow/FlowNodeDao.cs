using YcTeam.IDAL.Master;
using YcTeam.IDAL.System;
using YcTeam.IDAL.WorkFlow;
using YcTeam.Models;
using YcTeam.Models.Master;
using YcTeam.Models.Sys;
using YcTeam.Models.WorkFlow;

namespace YcTeam.DAL.WorkFlow
{
    public class FlowNodeDao : BaseService<FlowNode>, IFlowNodeDao
    {
        public FlowNodeDao() : base(new YcContext())
        {

        }
    }
}
