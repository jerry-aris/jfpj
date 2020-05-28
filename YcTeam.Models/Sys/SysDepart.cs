using System;

namespace YcTeam.Models.Sys
{
    /// <summary>
    /// 系统部门
    /// </summary>
    public class SysDepart : BaseEntity
    {
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartName { get; set; }

        /// <summary>
        /// 市级单位名称
        /// </summary>
        public string RegionCity { get; set; }

        /// <summary>
        /// 县级单位名称
        /// </summary>
        public string RegionCounty { get; set; }
    }
}
