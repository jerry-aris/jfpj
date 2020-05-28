using System;
using System.ComponentModel.DataAnnotations.Schema;
using YcTeam.Models.Master;

namespace YcTeam.Models.Planing
{
    public class Plan : BaseEntity
    {
        /// <summary>
        /// 计划数量
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 物料编号
        /// </summary>
        [ForeignKey(nameof(Material))]
        public Guid MaterialId { get; set; }
        
        /// <summary>
        /// 物料实体
        /// </summary>
        public EvContent Material { get; set; }

        /// <summary>
        /// 参考价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 需求日期
        /// </summary>
        public DateTime PlanDate { get; set; }

        /// <summary>
        /// 项目编号
        /// </summary>
        [ForeignKey(nameof(Project))]
        public Guid ProjectId { get; set; }

        /// <summary>
        /// 项目实体
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
