﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YcTeam.DTO.Master;
using YcTeam.DTO.System;
using YcTeam.Models.Sys;
using YcTeam.Models.WorkFlow;

namespace YcTeam.IBLL.WorkFlow
{
    public interface IFlowNodeService
    {
        Task CreateFlowNode(FlowNode flowNode);

        Task<List<FlowNode>> GetAllFlowNode();

        Task<FlowNode> GetFlowNodeByNodeName(string nodeName);
    }
}
