using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YcTeam.Models.WorkFlow
{
    public class FlowRecord : BaseEntity
    {
        /// <summary>
        /// 流程实例Id
        /// </summary>
        [ForeignKey(nameof(FlowInstance))]
        public Guid? WorkId { get; set; }

        //流程实例
        public FlowInstance FlowInstance { get; set; }

        /// <summary>
        /// 当前节点编号
        /// </summary>
        public Guid CurrentNodeNumber { get; set; }

        /// <summary>
        /// 当前节点名称
        /// </summary>
        [MaxLength(50)]
        public string CurrentNode { get; set; }

        /// <summary>
        /// 操作人Id
        /// </summary>
        public Guid? OperateUserId { get; set; }

        /// <summary>
        /// 操作人名称
        /// </summary>
        [MaxLength(50)]
        public string OperateUser { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }


        /// <summary>
        /// 是否读取
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// 是否通过
        /// </summary>
        public bool IsPass { get; set; }
    }
}
