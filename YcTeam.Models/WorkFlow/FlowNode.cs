using System;
using System.ComponentModel.DataAnnotations;

namespace YcTeam.Models.WorkFlow
{
    public class FlowNode : BaseEntity
    {
        /// <summary>
        /// 节点编号
        /// </summary>
        [Required]
        public Guid NodeNumber { get; set; }

        /// <summary>
        /// 节点名称
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string NodeName { get; set; }

        /// <summary>
        /// 执行人Id
        /// </summary>
        public Guid? OperateUserId { get; set; }

        /// <summary>
        ///执行人名称
        /// </summary>
        public string OperateUser { get; set; }

        /// <summary>
        /// 下一节点编号
        /// </summary>
        public string NextNodeNumber { get; set; }

        /// <summary>
        /// 上一节点编号（退回节点）
        /// </summary>
        public string LastNodeNumber { get; set; }


        public DateTime UpdateTime { get; set; }
    }
}
