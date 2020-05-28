using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YcTeam.BLL.WorkFlow;
using YcTeam.IBLL.WorkFlow;
using YcTeam.Models.Sys;
using YcTeam.Models.WorkFlow;
using YcTeam.MVCSite.Filters;

namespace YcTeam.MVCSite.Controllers
{
    public class FlowController : Controller
    {
        readonly IFlowInstanceService _flowInstanceSvc = new FlowInstanceService();
        readonly IFlowNodeService _flowNodeService = new FlowNodeService();

        // GET: Flow
        public ActionResult Index()
        {
            return View();
        }

        [UserAuth]
        public ActionResult Save()
        {
            //当前登录人员信息
            var userInfo = Session[CommonSession.CurrentUser] as SysUser;
            if (userInfo != null)
            {
                //request.CreateTime = DateTime.Now;
                //1.保存请假单
                //context.LeaveRequests.AddOrUpdate(request);

                var Bid = Guid.NewGuid(); //业务Id

                //2.创建工作流
                var flowInstance = new FlowInstance
                {
                    //工作流当前节点
                    NodeNumber = _flowNodeService.GetFlowNodeByNodeName("发起申请").Result.NodeNumber,
                    NodeName = "发起申请",
                    //申请处理状态
                    StatusName = "已申请",
                    //申请人（流程发起人）
                    StartUserId = userInfo.Id,
                    StartUser = userInfo.RealName,
                    //当前操作者
                    OperatingUserId = userInfo.Id,
                    OperatingUser = userInfo.RealName,
                    //下一个节点处理人
                    ToDoUserId = _flowNodeService.GetFlowNodeByNodeName("部门经理审批").Result.OperateUserId,
                    ToDoUser = _flowNodeService.GetFlowNodeByNodeName("部门经理审批").Result.OperateUser,
                    ////申请单ID
                    RequisitionId = Bid,
                    UpdateTime = DateTime.Now,
                    CreateTime = DateTime.Now,
                    //已操作过的人
                    OperatedUserId = userInfo.Id,
                    OperatedUser = userInfo.RealName
                };
                
                //添加
                _flowInstanceSvc.CreateFlowInstance(flowInstance);

                ////3.新建流操作记录
                var flowRecord = new FlowRecord
                {
                    WorkId = flowInstance.Id,//流程实例Id
                    OperateUser = userInfo.RealName, //当前处理人
                    OperateUserId = userInfo.Id,
                    CurrentNodeNumber = flowInstance.NodeNumber,////当前节点
                    CurrentNode = flowInstance.NodeName,
                    IsRead = true,////是否已读
                    IsPass = true,////是否通过
                    UpdateTime = DateTime.Now
                };
            }
            return View();
        }

        /// <summary>
        /// 获取待办审批
        /// </summary>
        /// <returns></returns>
        public ActionResult GetList(int page)
        {
            //当前登录人员信息
            var userInfo = Session[CommonSession.CurrentUser] as SysUser;
            if (userInfo!=null)
            {
                //此处获取待办人列表，根据待办人Id 等于 当前登录用户Id获取
                var list = _flowInstanceSvc.GetAllFlowInstance().Result
                    .Where(x => x.ToDoUserId == userInfo.Id)
                    .OrderByDescending(x => x.CreateTime)
                    .ToList(); 

                var count = list.Count();
                //var pagedList = list.ToPage(page, count).ToList();

                //var todoList = pagedList.Select(x => new
                //{
                //    x.Id,
                //    x.Starter,//申请人
                //    x.Operator, //上一操作人
                //    UpdateTime = x.UpdateTime.Format("yyyy年MM月dd日 hh:mm"), //更新时间,
                //    x.RequisitionId //对应申请单id
                //}).ToList();
            }
            return View();
        }
    }
}