using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YcTeam.Models.Sys
{
    /// <summary>
    /// 系统用户
    /// </summary>
    public class SysUser : BaseEntity
    {
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 所属部门
        /// </summary>
        [ForeignKey(nameof(SysDepart))]
        public Guid SysDepartId { get; set; }

        public SysDepart SysDepart { get; set; }
        /// <summary>
        /// 当前职位状态
        /// </summary>
        public int CurrentStaffState { get; set; }

        /// <summary>
        /// 所属角色配置
        /// </summary>
        public List<SysUserRole> SysUserRoles { get; set; }
    }
}
