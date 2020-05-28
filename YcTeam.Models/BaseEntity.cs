using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YcTeam.Models
{
    public class BaseEntity
    {
        /// <summary>
        /// 编号
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// 职位状态
        /// </summary>
        public int StaffState { get; set; }
        /// <summary>
        /// 职位状态名称
        /// </summary>
        public string StaffStateName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 是否被删除(伪删除)
        /// </summary>
        public bool IsRemoved { get; set; }
    }
}
