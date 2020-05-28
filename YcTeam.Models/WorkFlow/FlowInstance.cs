using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YcTeam.Models.WorkFlow
{
    public class FlowInstance : BaseEntity
    {
        /// <summary>
        /// 当前节点
        /// </summary>
        [Required]
        [ForeignKey(nameof(FlowNode))]
        public Guid NodeNumber { get; set; }

        public FlowNode FlowNode { get; set; }

        /// <summary>
        /// 节点名称
        /// </summary>
        [MaxLength(50)]
        public string NodeName { get; set; }

        /// <summary>
        /// 流状态
        /// </summary>
        public string StatusName { get; set; }


        /// <summary>
        /// 流程发起人userId
        /// </summary>
        public Guid? StartUserId { get; set; }

        /// <summary>
        /// 流程发起人姓名
        /// </summary>
        public string StartUser { get; set; }

        /// <summary>
        /// 当前操作人userId
        /// </summary>
        public Guid? OperatingUserId { get; set; }

        /// <summary>
        /// 当前操作人姓名
        /// </summary>
        public string OperatingUser { get; set; }

        /// <summary>
        /// 待办人Id
        /// </summary>
        public Guid? ToDoUserId { get; set; }

        /// <summary>
        /// 待办人名称
        /// </summary>
        public string ToDoUser { get; set; }

        /// <summary>
        /// 已操作人编号
        /// </summary>
        public Guid OperatedUserId { get; set; }

        /// <summary>
        /// 已操作人
        /// </summary>
        public string OperatedUser { get; set; }

        /// <summary>
        /// 流程更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 流程Id
        /// </summary>
        public Guid? RequisitionId { get; set; }
    }
}
